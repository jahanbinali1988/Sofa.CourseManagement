namespace Sofa.CourseManagement.Domain.Shared.Exceptions
{
    public enum ExceptionCodes
    {
        InvalidCorelationIdValueException = 3000,

        InvalidTitleValueException = 1001,
        InvalidContentValueException = 1002,
        InvalidOccurredDateValueException = 1003,
        InvalidCodeValueException = 1004,
        InvalidWebsiteUrlValueException = 1005,

        InvalidEmailValueException = 2001,
        InvalidNameValueException = 2002,
        InvalidPhoneNumberValueException = 2003,
        InvalidUserNameValueException = 2004,
    }
}
