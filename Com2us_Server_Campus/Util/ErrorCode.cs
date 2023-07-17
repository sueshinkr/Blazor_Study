﻿public enum ErrorCode : UInt16
{
    None = 0,
    GetVersionDataFailRedis = 1,
    GetVersionDataFailException = 2,
    RedisInitFailException = 3,
    MasterDbInitFailException = 4,

    // Account Error
    CreateAccountFailDuplicate = 1001,
    CreateAccountFailException = 1002,
    CreateBasicDataFailInsertItem = 1003,
    CreateBasicDataFailException = 1004,

    // Login Error
    LoginFailUserNotExist = 2001,
    LoginFailPwNotMatch = 2002,
    VerifyAccountFailException = 2003,
    VerifyVersionDataFailVersionNotMatch = 2004,
    VerifyVersionDataFailException = 2005,
    CreateUserAuthFailRedis = 2006,
    CreateUserAuthFailException = 2007,
    LoadNotificationFailNoUrl = 2008,
    LoadNotificationFailGetImageFromUrl = 2009,
    LoadNotificationFailException = 2010,

    InsertItemFailException = 3001,
    DeleteItemFailException = 3002,
    DeleteItemFailWrongData = 3003,
    UserDataLoadingFailException = 3004,
    UserItemLoadingFailException = 3005,

    // CheckAuth Error
    EmptyRequestHttpBody = 4001,
    InvalidRequestHttpBody = 4002,
    CheckUserGameDataNotMatch = 4003,
    UserNotRegisted = 4004,
    AuthTokenFailWrongAuthToken = 4005,
    AuthTokenFailSetNx = 4006,
    SetJsonFailException = 4007,

    // Mail Error
    LoadMailDataFailWrongPage = 5001,
    LoadMailDataFailNoData = 5002,
    LoadMailDataFailException = 5003,
    ReadMailFailWrongData = 5004,
    ReadMailFailException = 5005,
    ReceiveMailItemFailWrongData = 5006,
    ReceiveMailItemFailAlreadyGet = 5007,
    ReceiveMailItemFailInsertItem = 5008,
    ReceiveMailItemFailException = 5009,
    InsertMailItemToUserItemFailException = 5010,
    UpdateMailItemReceiveStatusFailException = 5011,
    DeleteMailFailWrongData = 5012,
    DeleteMailFailException = 5013,
    InsertItemIntoMailFailException = 5014,

    // Attendance Error
    LoadAttendanceDataFailWrongUser = 6001,
    LoadAttendanceDataFailSendMail = 6002,
    LoadAttendanceDataFailException = 6003,
    LoadUserCurrentAttendanceFailWrongUser = 6004,
    UpdateUserAttendanceNotNewAttendance = 6005,
    UpdateUserAttendanceFailException = 6006,
    HandleNewAttendanceFailException = 6007,
    SendMailAttendanceRewardFailAlreadyAttend = 6008,
    SendMailAttendanceRewardFailInsertItemIntoMail = 6009,
    SendMailAttendanceRewardFailException = 6010,

    // InApp Error
    PurchaseInAppProductFailDuplicate = 7001,
    PurchaseInAppProductFailException = 7002,
    SendMailInAppProductFailException = 7003,

    // Enhance Error
    CheckEnhanceableFailWrongData = 8001,
    CheckEnhanceableFailNotEnhanceable = 8002,
    CheckEnhanceableFailAlreadyMax = 8003,
    CheckEnhanceableFailNotEnoughMoney = 8004,
    CheckEnhanceableFailException = 8005,
    HandleSuccessfulEnhancementFailException = 8006,
    HandleFailedEnhancementFailException = 8007,
    EnhanceItemFailException = 8008,

    // Dungeon Error
    LoadLoadStageListFailException = 9001,
    SelectStageFailNotQualified = 9002,
    SelectStageFailWrongStage = 9003,
    SelectStageFailException = 9004,
    CreateStageProgressDataFailInProgress = 9005,
    CreateStageProgressDataFailAlreadyInDifferentStage = 9006,
    CreateStageProgressDataFailRedis = 9007,
    CreateStageProgressDataFailException = 9008,
    DeleteStageProgressDataFailRedis = 9009,
    DeleteStageProgressDataFailException = 9010,
    CheckUserInProgressFailWrongKey = 9011,
    ObtainItemFailWrongItem = 9012,
    ObtainItemFailToManyItem = 9013,
    ObtainItemFailRedis = 9014,
    ObtainItemFailException = 9015,
    KillEnemyFailWrongEnemy = 9016,
    killEnemyFailToManyEnemy = 9017,
    KillEnemyFailRedis = 9018,
    KillEnemyFailException = 9019,
    CheckStageClearDataFailWrongKey = 9020,
    CheckStageClearDataFailWrongStage = 9021,
    CheckStageClearDataFailNotComplete = 9022,
    CheckStageClearDataFailException = 9023,
    ReceiveItemRewardFailInsertItem = 9024,
    ReceiveItemRewardFailException = 9025,
    ReceiveExpRewardFailException = 9026,
    ReceiveStageClearRewardFailException = 9027,
    UpdateStageClearDataFailException = 9028,

    // Chat Error
    EnterChatLobbyFromLoginFailLobbyFull = 10001,
    EnterChatLobbyFromLoginFailRedis = 10002,
    EnterChatLobbyFromLoginFailException = 10003,
    LoadUserCurrentLobbyFailWrongUser = 10004,
    SelectChatLobbyFailAlreadyIn = 10005,
    SelectChatLobbyFailLobbyFull = 10006,
    SelectChatLobbyFailRedis = 10007,
    SelectChatLobbyFailException = 10008,
    SendChatFailWrongUser = 10009,
    SendChatFailRedis = 10010,
    SendChatFailException = 10011,
    ReceiveChatFailWrongUser = 10012,
    ReceiveChatFailException = 10013,

	// Managing Error
	GetUserDataFromUserIdFailException = 11001
}