uses SplashKit, TestFramework

type
TTestNetworking = class(TTestCase)
protected
procedure TIntegrationTests.TestAcceptAllNewConnectionsIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    connectionsAccepted := AcceptAllNewConnections();
    AssertTrue(connectionsAccepted);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestAcceptNewConnectionIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    connectionAccepted := AcceptNewConnection(testServer);
    AssertTrue(connectionAccepted);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestBroadcastMessageIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection1 := OpenConnection('test_connection1', '127.0.0.1', 5000);
    testConnection2 := OpenConnection('test_connection2', '127.0.0.1', 5000);
    CheckNetworkActivity();
    BroadcastMessage('Test Message', testServer);
    CheckNetworkActivity();
    AssertTrue(HasMessages(testConnection1));
    AssertTrue(HasMessages(testConnection2));
    CloseAllConnections();
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestBroadcastMessageToAllIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection1 := OpenConnection('test_connection', '127.0.0.1', 5000);
    testConnection2 := OpenConnection('test_connection2', '127.0.0.1', 5000);
    CheckNetworkActivity();
    BroadcastMessage('Test Message');
    CheckNetworkActivity();
    AssertTrue(HasMessages(testConnection1));
    AssertTrue(HasMessages(testConnection2));
    CloseAllConnections();
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestBroadcastMessageToServerNamedIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    BroadcastMessage('Test Message', 'test_server');
    CheckNetworkActivity();
    AssertTrue(HasMessages(testConnection));
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestCheckNetworkActivityIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    AssertTrue(HasNewConnections());
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestClearMessagesFromNameIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    AssertTrue(HasMessages(testConnection));
    ClearMessages('test_connection');
    CheckNetworkActivity();
    AssertFalse(HasMessages(testConnection));
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestClearMessagesFromConnectionIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    AssertTrue(HasMessages(testConnection));
    ClearMessages(testConnection);
    AssertFalse(HasMessages(testConnection));
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestClearMessagesFromServerIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 8080);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    AssertTrue(HasMessages(testServer));
    ClearMessages(testServer);
    CheckNetworkActivity();
    AssertFalse(HasMessages(testServer));
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestCloseAllConnectionsIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    AssertTrue(HasConnection('test_connection'));
    CloseAllConnections();
    CheckNetworkActivity();
    AssertFalse(HasConnection('test_connection'));
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestCloseAllServersIntegration;
begin
    CreateServer('test_server_1', 5000);
    CreateServer('test_server_2', 5001);
    AssertTrue(HasServer('test_server_1'));
    AssertTrue(HasServer('test_server_2'));
    CloseAllServers();
    AssertFalse(HasServer('test_server_1'));
    AssertFalse(HasServer('test_server_2'));
end;
procedure TIntegrationTests.TestCloseConnectionIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 8080);
    CheckNetworkActivity();
    closeResult := CloseConnection(testConnection);
    AssertTrue(closeResult);
    AssertFalse(IsConnectionOpen(testConnection));
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestCloseConnectionNamedIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 8080);
    CheckNetworkActivity();
    AssertTrue(IsConnectionOpen(testConnection));
    closeResult := CloseConnection('test_connection');
    AssertTrue(closeResult);
    AssertFalse(IsConnectionOpen(testConnection));
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestCloseMessageIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    AssertTrue(HasMessages());
    testMessage := ReadMessage();
    AssertNotNull(testMessage);
    CloseMessage(testMessage);
    AssertFalse(HasMessages());
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestCloseServerNamedIntegration;
begin
    CreateServer('test_server', 5000);
    closeResult := CloseServer('test_server');
    AssertTrue(closeResult);
    AssertFalse(HasServer('test_server'));
end;
procedure TIntegrationTests.TestCloseServerIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    closeResult := CloseServer(testServer);
    AssertTrue(closeResult);
    AssertFalse(HasServer('test_server'));
end;
procedure TIntegrationTests.TestConnectionCountNamedIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    AssertEquals(1, ConnectionCount('test_server'));
    CloseAllConnections();
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestConnectionCountIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    AssertEquals(1, ConnectionCount(testServer));
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestConnectionIPIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    testIP := ConnectionIP(testConnection);
    AssertEquals(2130706433, testIP);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestConnectionIPFromNameIntegration;
begin
    testServer := CreateServer('test_server', 8080);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 8080);
    CheckNetworkActivity();
    testIP := ConnectionIP('test_connection');
    AssertEquals(2130706433, testIP);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestConnectionNamedIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    retrievedConnection := ConnectionNamed('test_connection');
    AssertNotNull(retrievedConnection);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestConnectionPortIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    testPort := ConnectionPort(testConnection);
    AssertEquals(5000, testPort);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestConnectionPortFromNameIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    testPort := ConnectionPort('test_connection');
    AssertEquals(5000, testPort);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestCreateServerWithPortIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    AssertNotNull(testServer);
    AssertTrue(HasServer('test_server'));
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestCreateServerWithPortAndProtocolIntegration;
begin
    testServer := CreateServer('test_server', 5000, ConnectionType.TCP);
    AssertNotNull(testServer);
    AssertTrue(HasServer('test_server'));
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestDecToHexIntegration;
begin
    testHexResult := DecToHex(Cardinal(2130706433));
    AssertEquals('0x7F000001', testHexResult);
end;
procedure TIntegrationTests.TestFetchNewConnectionIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    newConnection := FetchNewConnection(testServer);
    AssertNotNull(newConnection);
    CloseConnection(newConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestHasConnectionIntegration;
begin
    testServer := CreateServer('test_server', 8080);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 8080);
    CheckNetworkActivity();
    AssertTrue(HasConnection('test_connection'));
    CloseConnection(testConnection);
    AssertFalse(HasConnection('test_connection'));
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestHasMessagesIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    AssertFalse(HasMessages());
    SendMessageTo('test_message', testConnection);
    CheckNetworkActivity();
    AssertTrue(HasMessages());
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestHasMessagesOnConnectionIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    AssertTrue(HasMessages(testConnection));
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestHasMessagesOnNameIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    AssertTrue(HasMessages('test_server'));
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestHasMessagesOnServerIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    AssertTrue(HasMessages(testServer));
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestHasNewConnectionsIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    AssertTrue(HasNewConnections());
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestHasServerIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    AssertTrue(HasServer('test_server'));
    CloseServer(testServer);
    AssertFalse(HasServer('test_server'));
end;
procedure TIntegrationTests.TestHexStrToIpv4Integration;
begin
    testIpv4 := HexStrToIpv4('0x7F000001');
    AssertEquals('127.0.0.1', testIpv4);
    testIpv4NoPrefix := HexStrToIpv4('7F000001');
    AssertEquals('127.0.0.1', testIpv4NoPrefix);
end;
procedure TIntegrationTests.TestHexToDecStringIntegration;
begin
    testResult := HexToDecString('7F');
    AssertEquals('127', testResult);
    testResultWithPrefix := HexToDecString('0x7F');
    AssertEquals('127', testResultWithPrefix);
end;
procedure TIntegrationTests.TestIpv4ToDecIntegration;
begin
    testResult1 := Ipv4ToDec('127.0.0.1');
    AssertEquals(2130706433, testResult1);
    testResult2 := Ipv4ToDec('192.168.1.1');
    AssertEquals(3232235777, testResult2);
end;
procedure TIntegrationTests.TestIpv4ToHexIntegration;
begin
    testIpv4Hex := Ipv4ToHex('127.0.0.1');
    AssertEquals('0x7F000001', testIpv4Hex);
end;
procedure TIntegrationTests.TestIpv4ToStrIntegration;
begin
    testIPStr := Ipv4ToStr(Cardinal(2130706433));
    AssertEquals('127.0.0.1', testIPStr);
end;
procedure TIntegrationTests.TestIsConnectionOpenIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    AssertTrue(IsConnectionOpen(testConnection));
    CloseConnection(testConnection);
    AssertFalse(IsConnectionOpen(testConnection));
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestIsConnectionOpenFromNameIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    AssertTrue(IsConnectionOpen('test_connection'));
    CloseConnection(testConnection);
    AssertFalse(IsConnectionOpen('test_connection'));
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestLastConnectionNamedIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    lastConnection := LastConnection('test_server');
    AssertEquals(testConnection, lastConnection);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestLastConnectionIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    lastConnection := LastConnection(testServer);
    AssertEquals(testConnection, lastConnection);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestMessageConnectionIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    testMessage := ReadMessage(testServer);
    AssertEquals(testConnection, MessageConnection(testMessage));
    CloseMessage(testMessage);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestMessageCountOnServerIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    AssertEquals(1, MessageCount(testServer));
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestMessageCountOnConnectionIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    AssertTrue(MessageCount(testConnection) > 0);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestMessageCountFromNameIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    AssertEquals(1, MessageCount(testServer));
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestMessageDataIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    testMessage := ReadMessage(testServer);
    AssertEquals('Test Message', MessageData(testMessage));
    CloseMessage(testMessage);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestMessageDataBytesIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    testMessage := ReadMessage(testServer);
    testMessageBytes := MessageDataBytes(testMessage);
    AssertTrue(Length(testMessageBytes) > 0);
    CloseMessage(testMessage);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestMessageHostIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    testMessage := ReadMessage(testServer);
    AssertEquals('127.0.0.1', MessageHost(testMessage));
    CloseMessage(testMessage);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestMessagePortIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    testMessage := ReadMessage(testServer);
    AssertEquals(5000, MessagePort(testMessage));
    CloseMessage(testMessage);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestMessageProtocolIntegration;
begin
    testServer := CreateServer('test_server', 5000, ConnectionType.UDP);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000, ConnectionType.UDP);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    testMessage := ReadMessage(testServer);
    AssertEquals(ConnectionType.UDP, MessageProtocol(testMessage));
    CloseMessage(testMessage);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestMyIPIntegration;
begin
    testIP := MyIP();
    AssertEquals('127.0.0.1', testIP);
end;
procedure TIntegrationTests.TestNameForConnectionIntegration;
begin
    testConnectionName := NameForConnection('localhost', Cardinal(8080));
    AssertEquals('localhost:8080', testConnectionName);
end;
procedure TIntegrationTests.TestNewConnectionCountIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    AssertEquals(1, NewConnectionCount(testServer));
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestOpenConnectionIntegration;
begin
    testServer := CreateServer('test_server', 8080);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 8080);
    CheckNetworkActivity();
    AssertNotNull(testConnection);
    AssertTrue(IsConnectionOpen(testConnection));
    CloseConnection(testConnection);
    AssertFalse(IsConnectionOpen(testConnection));
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestOpenConnectionWithProtocolIntegration;
begin
    testServer := CreateServer('test_server', 5000, ConnectionType.TCP);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000, ConnectionType.TCP);
    CheckNetworkActivity();
    AssertNotNull(testConnection);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestReadMessageIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    testMessage := ReadMessage();
    AssertEquals('Test Message', MessageData(testMessage));
    CloseMessage(testMessage);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestReadMessageFromConnectionIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    testMessage := ReadMessage(testConnection);
    AssertEquals('Test Message', MessageData(testMessage));
    CloseMessage(testMessage);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestReadMessageFromNameIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    testMessage := ReadMessage('test_server');
    AssertEquals('Test Message', MessageData(testMessage));
    CloseMessage(testMessage);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestReadMessageFromServerIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    testMessage := ReadMessage(testServer);
    AssertEquals('Test Message', MessageData(testMessage));
    CloseConnection(testConnection);
    CloseServer(testServer);
    CloseMessage(testMessage);
end;
procedure TIntegrationTests.TestReadMessageDataFromNameIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    AssertEquals('Test Message', ReadMessageData('test_server'));
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestReadMessageDataFromConnectionIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    AssertEquals('Test Message', ReadMessageData(testConnection));
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestReadMessageDataFromServerIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    AssertEquals('Test Message', ReadMessageData(testServer));
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestReconnectIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    CloseConnection(testConnection);
    CheckNetworkActivity();
    AssertFalse(IsConnectionOpen(testConnection));
    Reconnect(testConnection);
    CheckNetworkActivity();
    AssertTrue(IsConnectionOpen(testConnection));
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestReconnectFromNameIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    CloseConnection(testConnection);
    CheckNetworkActivity();
    AssertFalse(IsConnectionOpen(testConnection));
    Reconnect('test_connection');
    CheckNetworkActivity();
    AssertTrue(IsConnectionOpen('test_connection'));
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestReleaseAllConnectionsIntegration;
begin
    CreateServer('test_server', 8080);
    OpenConnection('test_connection1', '127.0.0.1', 8080);
    OpenConnection('test_connection2', '127.0.0.1', 8080);
    CheckNetworkActivity();
    AssertTrue(HasConnection('test_connection1'));
    AssertTrue(HasConnection('test_connection2'));
    ReleaseAllConnections();
    AssertFalse(HasConnection('test_connection1'));
    AssertFalse(HasConnection('test_connection2'));
    AssertFalse(HasServer('test_server'));
end;
procedure TIntegrationTests.TestResetNewConnectionCountIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    AssertEquals(NewConnectionCount(testServer), 1);
    ResetNewConnectionCount(testServer);
    AssertEquals(0, NewConnectionCount(testServer));
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestRetrieveConnectionNamedIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    retrievedConnection := RetrieveConnection('test_connection', 0);
    AssertEquals(testConnection, retrievedConnection);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestRetrieveConnectionIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    retrievedConnection := RetrieveConnection(testServer, 0);
    AssertEquals(testConnection, retrievedConnection);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestSendMessageToConnectionIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    sendResult := SendMessageTo('Test Message', testConnection);
    CheckNetworkActivity();
    AssertTrue(sendResult);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestSendMessageToNameIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    testConnection := OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    sendResult := SendMessageTo('Test Message', 'test_connection');
    CheckNetworkActivity();
    AssertTrue(sendResult);
    CloseConnection(testConnection);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestServerHasNewConnectionNamedIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    AssertTrue(ServerHasNewConnection('test_server'));
    CloseServer(testServer);
    CloseAllConnections();
end;
procedure TIntegrationTests.TestServerHasNewConnectionIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    OpenConnection('test_connection', '127.0.0.1', 5000);
    CheckNetworkActivity();
    AssertTrue(ServerHasNewConnection(testServer));
    CloseServer(testServer);
    CloseAllConnections();
end;
procedure TIntegrationTests.TestServerNamedIntegration;
begin
    testServer := CreateServer('test_server', 5000);
    retrievedServer := ServerNamed('test_server');
    AssertEquals(testServer, retrievedServer);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestSetUDPPacketSizeIntegration;
begin
    SetUDPPacketSize(Cardinal(1024));
    AssertEquals(1024, UDPPacketSize());
end;
procedure TIntegrationTests.TestUDPPacketSizeIntegration;
begin
    testPacketSize := UDPPacketSize();
    AssertTrue(testPacketSize > 0);
end;
procedure TIntegrationTests.TestDownloadBitmapIntegration;
begin
    testServer := CreateServer('test_server', 8080);
    testWindow := OpenWindow('Test Window', 800, 600);
    testBitmap := DownloadBitmap('test_image', 'http://localhost:8080/test/resources/images/frog.png', 80);
    AssertNotNull(testBitmap);
    FreeBitmap(testBitmap);
    CloseWindow(testWindow);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestDownloadFontIntegration;
begin
    testServer := CreateServer('test_server', 8080);
    testFont := DownloadFont('test_font', 'http://localhost:8080/test/resources/fonts/hara.ttf', 80);
    AssertNotNull(testFont);
    FreeFont(testFont);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestDownloadMusicIntegration;
begin
    testServer := CreateServer('test_server', 8080);
    testMusic := DownloadMusic('test_music', 'http://localhost:8080/test/resources/music/280.mp3', 80);
    AssertNotNull(testMusic);
    FreeMusic(testMusic);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestDownloadSoundEffectIntegration;
begin
    testServer := CreateServer('test_server', 8080);
    testSoundEffect := DownloadSoundEffect('test_sound', 'http://localhost:8080/test/resources/sounds/breakdance.wav', 80);
    AssertNotNull(testSoundEffect);
    FreeSoundEffect(testSoundEffect);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestFreeResponseIntegration;
begin
    testServer := CreateServer('test_server', 8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    AssertNotNull(testResponse);
    FreeResponse(testResponse);
    AssertNull(testResponse);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestHttpGetIntegration;
begin
    testServer := CreateServer('test_server', 8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    AssertNotNull(testResponse);
    responseText := HttpResponseToString(testResponse);
    AssertTrue(Length(responseText) > 0);
    FreeResponse(testResponse);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestHttpPostWithHeadersIntegration;
begin
    testServer := CreateServer('test_server', 8080);
    headers := TArray<String>.Create('Content-Type: application/json', 'Accept: application/json');
    testResponse := HttpPost('http://localhost:8080/test', 80, 'Test Body', headers);
    AssertNotNull(testResponse);
    responseText := HttpResponseToString(testResponse);
    AssertTrue(Contains(responseText, 'Test Body'));
    FreeResponse(testResponse);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestHttpPostIntegration;
begin
    testServer := CreateServer('test_server', 8080);
    testResponse := HttpPost('http://localhost:8080/test', 80, 'Test Body');
    AssertNotNull(testResponse);
    responseText := HttpResponseToString(testResponse);
    AssertTrue(Contains(responseText, 'Test Body'));
    FreeResponse(testResponse);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestHttpResponseToStringIntegration;
begin
    testServer := CreateServer('test_server', 8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    responseText := HttpResponseToString(testResponse);
    AssertTrue(Length(responseText) > 0);
    FreeResponse(testResponse);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestSaveResponseToFileIntegration;
begin
    testServer := CreateServer('test_server', 8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    testFile := 'test_output.txt';
    SaveResponseToFile(testResponse, testFile);
    FreeResponse(testResponse);
    CloseServer(testServer);
end;
procedure TIntegrationTests.TestHasIncomingRequestsIntegration;
begin
    testServer := StartWebServer(8080);
    AssertFalse(HasIncomingRequests(testServer));
    testResponse := HttpGet('http://localhost:8080/test', 80);
    AssertTrue(HasIncomingRequests(testServer));
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestIsDeleteRequestForIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    AssertTrue(HasIncomingRequests(testServer));
    testRequest := NextWebRequest(testServer);
    AssertFalse(IsDeleteRequestFor(testRequest, '/test'));
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestIsGetRequestForIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    AssertTrue(HasIncomingRequests(testServer));
    testRequest := NextWebRequest(testServer);
    AssertTrue(IsGetRequestFor(testRequest, '/test'));
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestIsOptionsRequestForIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    AssertTrue(HasIncomingRequests(testServer));
    testRequest := NextWebRequest(testServer);
    AssertFalse(IsOptionsRequestFor(testRequest, '/test'));
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestIsPostRequestForIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpPost('http://localhost:8080/test_path', 80, 'test=123');
    AssertTrue(HasIncomingRequests(testServer));
    testRequest := NextWebRequest(testServer);
    AssertTrue(IsPostRequestFor(testRequest, '/test_path'));
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestIsPutRequestForIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    AssertTrue(HasIncomingRequests(testServer));
    testRequest := NextWebRequest(testServer);
    AssertFalse(IsPutRequestFor(testRequest, '/test'));
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestIsRequestForIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    AssertTrue(HasIncomingRequests(testServer));
    testRequest := NextWebRequest(testServer);
    AssertTrue(IsRequestFor(testRequest, HttpMethod.HTTP_GET_METHOD, '/test'));
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestIsTraceRequestForIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    AssertTrue(HasIncomingRequests(testServer));
    testRequest := NextWebRequest(testServer);
    AssertFalse(IsTraceRequestFor(testRequest, '/test'));
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestNextWebRequestIntegration;
begin
    testServer := StartWebServer(8080);
    AssertFalse(HasIncomingRequests(testServer));
    testRequest := NextWebRequest(testServer);
    AssertNull(testRequest);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestRequestBodyIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpPost('http://localhost:8080/test', 80, 'test body');
    testRequest := NextWebRequest(testServer);
    AssertEquals('test body', RequestBody(testRequest));
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestRequestHasQueryParameterIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test?param1=value1', 80);
    testRequest := NextWebRequest(testServer);
    AssertTrue(RequestHasQueryParameter(testRequest, 'param1'));
    AssertFalse(RequestHasQueryParameter(testRequest, 'nonexistent_param'));
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestRequestHeadersIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    testRequest := NextWebRequest(testServer);
    AssertTrue(Length(RequestHeaders(testRequest)) > 0);
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestRequestMethodIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    testRequest := NextWebRequest(testServer);
    AssertEquals(HttpMethod.HTTP_GET_METHOD, RequestMethod(testRequest));
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestRequestQueryParameterIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test?param1=value1', 80);
    testRequest := NextWebRequest(testServer);
    testResult := RequestQueryParameter(testRequest, 'param1', 'default_value');
    AssertEquals('value1', testResult);
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestRequestQueryStringIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test?param1=value1', 80);
    testRequest := NextWebRequest(testServer);
    testQueryString := RequestQueryString(testRequest);
    AssertEquals('param1=value1', testQueryString);
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestRequestURIIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    testRequest := NextWebRequest(testServer);
    testURI := RequestURI(testRequest);
    AssertEquals('/test', testURI);
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestRequestURIStubsIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test/path', 80);
    testRequest := NextWebRequest(testServer);
    testStubs := RequestURIStubs(testRequest);
    AssertEquals(TArray<String>.Create('test', 'path'), testStubs);
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestSendCSSFileResponseIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test.css', 80);
    testRequest := NextWebRequest(testServer);
    SendCSSFileResponse(testRequest, 'test.css');
    AssertTrue(IsRequestFor(testRequest, HttpMethod.HTTP_GET_METHOD, '/test.css'));
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestSendFileResponseIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test.txt', 80);
    testRequest := NextWebRequest(testServer);
    SendFileResponse(testRequest, 'test.txt', 'text/plain');
    AssertTrue(IsRequestFor(testRequest, HttpMethod.HTTP_GET_METHOD, '/test.txt'));
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestSendHtmlFileResponseIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test.html', 80);
    testRequest := NextWebRequest(testServer);
    SendHtmlFileResponse(testRequest, 'test.html');
    AssertTrue(IsRequestFor(testRequest, HttpMethod.HTTP_GET_METHOD, '/test.html'));
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestSendJavascriptFileResponseIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test.js', 80);
    testRequest := NextWebRequest(testServer);
    SendJavascriptFileResponse(testRequest, 'test.js');
    AssertTrue(IsRequestFor(testRequest, HttpMethod.HTTP_GET_METHOD, '/test.js'));
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestSendResponseEmptyIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    testRequest := NextWebRequest(testServer);
    SendResponse(testRequest);
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestSendResponseIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    testRequest := NextWebRequest(testServer);
    SendResponse(testRequest, 'Test Message');
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestSendResponseJsonWithStatusIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    testRequest := NextWebRequest(testServer);
    SendResponse(testRequest, HttpStatusCode.HTTP_STATUS_OK);
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestSendResponseWithStatusIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    testRequest := NextWebRequest(testServer);
    SendResponse(testRequest, HttpStatusCode.HTTP_STATUS_OK, 'Test Message');
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestSendResponseWithStatusAndContentTypeIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    testRequest := NextWebRequest(testServer);
    SendResponse(testRequest, HttpStatusCode.HTTP_STATUS_OK, 'Test Message', 'text/plain');
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestSendResponseWithStatusAndContentTypeAndHeadersIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    testRequest := NextWebRequest(testServer);
    SendResponse(testRequest, HttpStatusCode.HTTP_STATUS_OK, 'Test Message', 'text/plain', TArray<String>.Create('Header1: Value1', 'Header2: Value2'));
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestSendResponseJsonIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    testRequest := NextWebRequest(testServer);
    testJson := CreateJson();
    JsonSetString(testJson, 'message', 'Test Message');
    SendResponse(testRequest, testJson);
    FreeResponse(testResponse);
    FreeJson(testJson);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestSplitURIStubsIntegration;
begin
    testStubs := SplitURIStubs('/names/0');
    AssertEquals(TArray<Integer>.Create('names', '0'), testStubs);
    testStubsEmpty := SplitURIStubs('/');
    AssertTrue(Length(testStubsEmpty) = 0);
end;
procedure TIntegrationTests.TestStartWebServerWithDefaultPortIntegration;
begin
    testServer := StartWebServer();
    AssertNotNull(testServer);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestStartWebServerIntegration;
begin
    testServer := StartWebServer(8080);
    AssertNotNull(testServer);
    StopWebServer(testServer);
end;
procedure TIntegrationTests.TestStopWebServerIntegration;
begin
    testServer := StartWebServer(8080);
    testResponse := HttpGet('http://localhost:8080/test', 80);
    AssertTrue(HasIncomingRequests(testServer));
    FreeResponse(testResponse);
    StopWebServer(testServer);
end;
end;

procedure RegisterTests;
begin
#<Proc:0x00007f20a9d04780 /mnt/c/Users/Noahc/Documents/.Year 2 Semester 3/Team Project (A)/Github Repo/splashkit_test_generator/test_generator/config/languages/pascal_config.rb:128 (lambda)>
end;
