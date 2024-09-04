using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static readonly BaseException SALE_ALREADY_EXIST = new BaseException("해당 품목으로 생성된 판매 내역이 이미 존재합니다.", 4001, 400);

        // 품목 3000
        public static readonly BaseException MATCHING_ALREADY_CONFIRMED = new BaseException("전체 확정되어 견적서를 추가할 수 없습니다.", 5000, 400);
        public static readonly BaseException MATCHING_NOT_FOUND = new BaseException("매칭 내역을 찾을 수 없습니다.", 5001, 404);
        public static readonly BaseException MATCHING_ALREADY_EXIST = new BaseException("이미 존재하는 매칭입니다.", 5002, 400);
        public static readonly BaseException MATCHING_NOT_CONFIRMED = new BaseException("견적서 전체 확정이 되지 않았습니다.", 5003, 400);
        public static readonly BaseException MATCHING_USER_NOT_FOUND = new BaseException("매칭 유저가 존재하지 않기 때문에 견적서를 추가할 수 없습니다.", 5004, 404);
        
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
