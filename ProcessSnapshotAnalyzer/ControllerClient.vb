Imports System.Net
Imports System.Text
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class ControllerClient

    Private httpC As Http.HttpClient
    Private httpHandler As New HttpClientHandler()
    Private cookies As New CookieContainer()
    Private Controller As ControllerInfo
    Private JSESSIONID_cookie As String
    'Private XCSRFTOKEN_cookie As String

    Public Sub New(ControllerIn As ControllerInfo)
        Controller = ControllerIn
        httpHandler.CookieContainer = cookies
        httpC = New HttpClient(httpHandler)
        httpC.DefaultRequestHeaders.Add("Authorization", "Basic " + Encode64(Controller.User + "@" + Controller.AccountName + ":" + Controller.Pass))
        Controller.URL = Controller.URL.TrimEnd("/")
        Authenticate()
    End Sub

    Public Function IsAuthenticated() As Boolean
        Dim httpResp As HttpResponseMessage
        Try
            Dim authURI As Uri = New Uri(Controller.URL + "/controller/restui/notificationUiService/notifications")
            Dim httpReq As New Http.HttpRequestMessage()
            httpReq.Method = Http.HttpMethod.Get
            httpReq.RequestUri = authURI
            httpReq.Headers.Add("Accept", "*/*")

            httpResp = httpC.SendAsync(httpReq).Result
            JSESSIONID_cookie = cookies.GetCookies(authURI).Item("JSESSIONID").Value
            If httpResp.StatusCode = System.Net.HttpStatusCode.OK Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Sub Authenticate()
        Try
            If Not IsAuthenticated() Then
                Dim authURI As Uri = New Uri(Controller.URL + "/controller/auth?action=login")
                Dim httpReq As New Http.HttpRequestMessage()
                httpReq.Method = Http.HttpMethod.Get
                httpReq.RequestUri = authURI
                httpReq.Headers.Add("Accept", "*/*")

                Dim httpResp As HttpResponseMessage = httpC.SendAsync(httpReq).Result
                JSESSIONID_cookie = cookies.GetCookies(authURI).Item("JSESSIONID").Value
                If Not IsAuthenticated() Then Throw New Exception("Wrong Credentials?")
            End If
        Catch ex As Exception
            If IsNothing(ex.InnerException) Then
                Throw ex
            Else
                Throw ex.InnerException
            End If
        End Try

    End Sub

    Public Function GetProcessSnapshot(snapshot As ProcessSnapshotDescriptor) As ProcessSnapshot

        If Not IsAuthenticated() Then Authenticate()
        Dim reqURL As String = Controller.URL + "/restui/snapshot/getProcessCallGraphRoot"
        reqURL += "?processSnapshotGUID=" + snapshot.requestGUID
        reqURL += "&timeRange=Custom_Time_Range.BETWEEN_TIMES."
        reqURL += snapshot.serverStartTime.ToString() + "."
        reqURL += snapshot.serverStartTime.ToString() + ".60"

        Dim wc As New WebClient()
        wc.Headers.Add("Accept", "application/json")
        wc.Headers.Add("Cookie", "JSESSIONID=" + JSESSIONID_cookie + ";")
        Dim j As String = wc.DownloadString(reqURL)
        Dim retVal As New ProcessSnapshot(j)
        retVal.GUID = snapshot.requestGUID
        Return retVal

    End Function

    Public Function GetProcessSnapshotList(criteria As ProcessSnapshotSearchCriteria) As ProcessSnapshotList
        Dim json As String = GetProcessSnapshotListAsJSON(criteria)
        Return New ProcessSnapshotList(json)
    End Function

    Private Function GetProcessSnapshotListAsJSON(criteria As ProcessSnapshotSearchCriteria) As String
        If Not IsAuthenticated() Then Authenticate()
        Dim ReqURL As String = Controller.URL + "/controller/restui/snapshot/getProcessSnapshots"
        Return PostUrlAsString(ReqURL, criteria.toJSON, "application/json")
    End Function

    Private Function GetUrlAsString(URL As String, AcceptType As String) As String

        If Not IsAuthenticated() Then Authenticate()
        Dim httpReq As New Http.HttpRequestMessage()
        httpReq.Method = Http.HttpMethod.Get
        httpReq.RequestUri = New Uri(URL)
        httpReq.Headers.Accept.Add(New MediaTypeWithQualityHeaderValue(AcceptType))
        httpReq.Headers.Add("Cookie", "JSESSIONID=" + JSESSIONID_cookie + ";")

        Dim httpResp As HttpResponseMessage = httpC.SendAsync(httpReq).Result
        Return httpResp.Content.ReadAsStringAsync().Result

    End Function

    Private Function GetUrlAsString(URL As String) As String

        If Not IsAuthenticated() Then Authenticate()
        Dim httpResp As HttpResponseMessage
        httpResp = httpC.GetAsync(URL).Result

        Return (httpResp.Content.ReadAsStringAsync().Result)

    End Function

    Private Function PostUrlAsString(URL As String, data As String, Optional ContentType As String = "application/json") As String

        If Not IsAuthenticated() Then Authenticate()
        Dim httpResp As HttpResponseMessage
        Dim PostData As New StringContent(data)
        PostData.Headers.ContentType = New MediaTypeHeaderValue(ContentType)
        httpResp = httpC.PostAsync(URL, PostData).Result
        If httpResp.StatusCode = 401 Then
            Throw New Exception("Authentication Error - wrong username/password?")
        End If
        If httpResp.StatusCode <> 200 Then
            Throw New Exception("Bad status code on HTTP request: " + httpResp.StatusCode.ToString())
        End If
        Return (httpResp.Content.ReadAsStringAsync().Result)

    End Function

    Private Function Encode64(strIn As String) As String
        Dim strInBytes As Byte() = Encoding.UTF8.GetBytes(strIn)
        Return System.Convert.ToBase64String(strInBytes)
    End Function

End Class

Public Class ControllerInfo
    Public Property URL As String
    Public Property User As String
    Public Property Pass As String
    Public Property AccountName As String
End Class

