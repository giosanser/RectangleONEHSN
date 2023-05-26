# RectangleONEHSN

Test Back End Developer/.NET - Giovanni Sanchez

Instructions:

1. Execute SQL script included in Scripts folder
2. Change RectangleDBConnectionString in your appsettings.json (Server=Your_server;Database=RectangleDB;User Id=your_user;Password=your_password;TrustServerCertificate=True;)
3. RectangleONEHSN project contains API 
4. RectangleAPI.Tests contains unit test (it includes two test)
5. it is implemented a basic authorization with encoded in base64 the user is "admin" and the password is "password"
6. API validates if receive invalid coordinates

API Endpoint
GetRectanglesForCoordinates
Method: POST
URL: https://localhost:7095/api/rectangle/coordinates
Headers:
Authorization: Basic YWRtaW46cGFzc3dvcmQ=
Accept: text/plain
Content-Type: application/json
Request Body:
csharp
Copy code
[
  [97, 10],
  [19, 21]
]
This API endpoint allows you to retrieve rectangles based on the provided coordinates. It expects a POST request with a JSON payload containing the coordinates. The Authorization header should be included with the Basic authentication credentials (base64-encoded username and password). The response will be in plain text format.

You can test the API endpoint using the provided cURL command:

bash
Copy code
curl -X 'POST' \
  'https://localhost:7095/api/rectangle/coordinates' \
  -H "Authorization: Basic YWRtaW46cGFzc3dvcmQ=" \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '[ [97, 10], [19, 21] ]'
