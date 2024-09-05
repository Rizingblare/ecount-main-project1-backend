using System;

namespace Ecount.Kjd.Project.CSharp
{
    public class BaseException : Exception
    {
        // 공통 에러 1000
        public static readonly BaseException PERMISSION_DENIED_METHOD_ACCESS = new BaseException("사용할 수 없는 기능입니다.", 1000, 403);
        public static readonly BaseException DATABASE_ERROR = new BaseException("데이터베이스 에러입니다.", 1001, 500);
        public static readonly BaseException USER_UNAUTHORIZED = new BaseException("인증되지 않았습니다.", 1002, 401);
        public static readonly BaseException INVALID_METHOD_ARGUMENTS = new BaseException("잘못된 매개변수가 입력되었습니다.", 1003, 400);
        public static readonly BaseException UNEXPECTED_EXCEPTION = new BaseException("예상치 못한 에러가 발생했습니다.", 1004, 500);

        // 판매 2000
        public static readonly BaseException SALE_ALREADY_EXIST = new BaseException("해당 판매 내역이 이미 존재합니다.", 2001, 400);
        public static readonly BaseException SALE_PRODUCT_ALREADY_EXIST = new BaseException("해당 품목으로 생성된 판매 내역이 이미 존재합니다.", 2002, 400);
        public static readonly BaseException SALE_NOT_EXIST = new BaseException("존재하지 않는 판매 내역에 대한 요청입니다.", 2003, 400);

        // 품목 3000
        public static readonly BaseException PRODUCT_ALREADY_EXIST = new BaseException("해당 품목이 이미 존재합니다.", 3001, 400);
        public static readonly BaseException PRODUCT_NOT_EXIST = new BaseException("존재하지 않는 품목에 대한 요청입니다.", 3002, 400);

        // 필드들
        public override string Message { get; }
        public int Code { get; }
        public int Status { get; }

        // 생성자
        private BaseException(string message, int code, int status)
        {
            Message = message;
            Code = code;
            Status = status;
        }

        public override string ToString()
        {
            return $"{Code} - {Message} (HTTP {Status})";
        }
    }
}
