public enum ErrorCode : UInt16
{
    None = 0,

    // Managing Error
    GetUserDataByUserIdFailException = 11001,
    GetUserDataByRangeFailException = 11002,
    GetItemTableFailException = 11003,
    SendMailFailInsertItemIntoMail = 11004,
    SendMailFailException = 11005
}