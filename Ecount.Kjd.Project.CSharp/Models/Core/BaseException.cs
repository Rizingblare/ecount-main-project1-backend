using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecount.Kjd.Project.CSharp
{
    public class BaseException
    {
        // 공통 에러 1000
        public static readonly BaseException PERMISSION_DENIED_METHOD_ACCESS = new BaseException("사용할 수 없는 기능입니다.", 1000, 403);
        public static readonly BaseException DATABASE_ERROR = new BaseException("데이터베이스 에러입니다.", 1001, 500);
        public static readonly BaseException USER_UNAUTHORIZED = new BaseException("인증되지 않았습니다.", 1002, 401);
        public static readonly BaseException INVALID_METHOD_ARGUMENTS = new BaseException("잘못된 매개변수가 입력되었습니다.", 1003, 400);
        public static readonly BaseException UNEXPECTED_EXCEPTION = new BaseException("예상치 못한 에러가 발생했습니다.", 1004, 500);

        // 회원 2000
        public static readonly BaseException USER_NOT_FOUND = new BaseException("서비스를 탈퇴했거나 가입하지 않은 유저의 요청입니다.", 2000, 404);
        public static readonly BaseException PLANNER_NOT_FOUND = new BaseException("서비스를 탈퇴하거나 가입하지 않은 플래너입니다.", 2001, 404);
        public static readonly BaseException USER_EMAIL_EXIST = new BaseException("동일한 이메일이 존재합니다.", 2002, 400);
        public static readonly BaseException USER_EMAIL_NOT_FOUND = new BaseException("이메일을 찾을 수 없습니다.", 2003, 400);
        public static readonly BaseException USER_ROLE_WRONG = new BaseException("role은 플래너, 또는 예비 부부만 가능합니다.", 2004, 400);
        public static readonly BaseException USER_PASSWORD_WRONG = new BaseException("패스워드를 잘못 입력하셨습니다.", 2005, 400);
        public static readonly BaseException USER_PASSWORD_NOT_SAME = new BaseException("패스워드1과 패스워드2는 동일해야 합니다.", 2006, 400);
        public static readonly BaseException USER_ALREADY_PREMIUM = new BaseException("이미 프리미엄 회원입니다.", 2007, 400);

        // 토큰 2100
        public static readonly BaseException ACCESS_TOKEN_EXPIRED = new BaseException("액세스 토큰이 만료되었습니다. 리프레시 토큰으로 다시 요청해주세요.", 2100, 401);
        public static readonly BaseException ACCESS_TOKEN_STILL_ALIVE = new BaseException("액세스 토큰이 아직 유효합니다. 이상한 접근이 감지되었습니다. 다시 로그인해주세요.", 2101, 401);
        public static readonly BaseException ALL_TOKEN_EXPIRED = new BaseException("모든 토큰이 만료되었습니다. 다시 로그인 해주세요.", 2102, 401);
        public static readonly BaseException TOKEN_NOT_FOUND = new BaseException("토큰을 찾을 수 없습니다. 다시 로그인 해주세요.", 2103, 404);
        public static readonly BaseException TOKEN_NOT_VALID = new BaseException("로그인 토큰이 유효하지 않습니다. 다시 로그인 해주세요.", 2104, 401);
        public static readonly BaseException TOKEN_REFRESH_FORBIDDEN = new BaseException("토큰을 갱신할 수 없습니다.", 2105, 401);
        public static readonly BaseException REFRESH_TOKEN_REQUIRED = new BaseException("리프레시 토큰을 가지고 다시 요청해주세요.", 2106, 401);

        // 이메일 2200
        public static readonly BaseException CODE_GENERATE_ERROR = new BaseException("인증코드 생성 과정에서 오류가 발생했습니다.", 2200, 500);
        public static readonly BaseException EMAIL_GENERATE_ERROR = new BaseException("이메일 생성 과정에서 오류가 발생했습니다.", 2201, 500);
        public static readonly BaseException CODE_NOT_FOUND = new BaseException("인증코드 전송 내역이 없습니다. 인증코드를 요청 후 진행해주세요.", 2202, 404);
        public static readonly BaseException CODE_EXPIRED = new BaseException("인증코드가 만료되었습니다. 다시 요청해주세요.", 2203, 400);
        public static readonly BaseException CODE_NOT_MATCHED = new BaseException("인증코드가 일치하지 않습니다.", 2204, 400);
        public static readonly BaseException UNAUTHENTICATED_EMAIL = new BaseException("인증되지 않은 이메일입니다.", 2205, 400);
        public static readonly BaseException EMAIL_ALREADY_AUTHENTICATED = new BaseException("이미 인증이 완료되었습니다.", 2206, 400);

        // 결제 3000
        public static readonly BaseException PAYMENT_WRONG_INFORMATION = new BaseException("잘못된 결제 정보입니다.", 3000, 400);
        public static readonly BaseException PAYMENT_NOT_FOUND = new BaseException("결제 내용이 존재하지 않습니다.", 3001, 404);
        public static readonly BaseException PAYMENT_FAIL = new BaseException("토스페이먼츠 승인 요청에 실패했습니다.", 3002, 400);

        // 포트폴리오 4000
        public static readonly BaseException PORTFOLIO_NOT_FOUND = new BaseException("해당하는 플래너의 포트폴리오가 삭제되었거나 존재하지 않습니다.", 4000, 404);
        public static readonly BaseException PORTFOLIO_ALREADY_EXIST = new BaseException("해당 플래너의 포트폴리오가 이미 존재합니다. 포트폴리오는 플래너당 하나만 생성할 수 있습니다.", 4001, 400);
        public static readonly BaseException PORTFOLIO_IMAGE_NOT_FOUND = new BaseException("포트폴리오 이미지를 불러올 수 없습니다.", 4002, 404);
        public static readonly BaseException PORTFOLIO_IMAGE_COUNT_EXCEED = new BaseException("요청한 이미지의 수가 5개를 초과합니다.", 4003, 400);
        public static readonly BaseException PORTFOLIO_IMAGE_CREATE_ERROR = new BaseException("포트폴리오 이미지 생성 과정에서 오류가 발생했습니다.", 4004, 500);
        public static readonly BaseException PORTFOLIO_IMAGE_ENCODING_ERROR = new BaseException("이미지 인코딩 과정에서 오류가 발생했습니다.", 4005, 500);
        public static readonly BaseException PORTFOLIO_CREATE_DIRECTORY_ERROR = new BaseException("포트폴리오 폴더 생성 과정에서 오류가 발생했습니다.", 4006, 500);
        public static readonly BaseException PORTFOLIO_CLEAN_DIRECTORY_ERROR = new BaseException("포트폴리오 폴더를 비우는 과정에서 오류가 발생했습니다.", 4007, 500);
        public static readonly BaseException PORTFOLIO_IMAGE_DELETE_ERROR = new BaseException("포트폴리오 이미지 삭제 과정에서 오류가 발생했습니다.", 4008, 500);
        public static readonly BaseException PORTFOLIO_IMAGE_PATH_ERROR = new BaseException("포트폴리오 이미지 경로를 구하는 과정에서 오류가 발생했습니다.", 4009, 500);

        // 매칭 관련 5000
        public static readonly BaseException MATCHING_ALREADY_CONFIRMED = new BaseException("전체 확정되어 견적서를 추가할 수 없습니다.", 5000, 400);
        public static readonly BaseException MATCHING_NOT_FOUND = new BaseException("매칭 내역을 찾을 수 없습니다.", 5001, 404);
        public static readonly BaseException MATCHING_ALREADY_EXIST = new BaseException("이미 존재하는 매칭입니다.", 5002, 400);
        public static readonly BaseException MATCHING_NOT_CONFIRMED = new BaseException("견적서 전체 확정이 되지 않았습니다.", 5003, 400);
        public static readonly BaseException MATCHING_USER_NOT_FOUND = new BaseException("매칭 유저가 존재하지 않기 때문에 견적서를 추가할 수 없습니다.", 5004, 404);

        // 견적서 관련 6000
        public static readonly BaseException QUOTATIONS_NOT_ALL_CONFIRMED = new BaseException("확정되지 않은 견적서가 있습니다.", 6000, 400);
        public static readonly BaseException QUOTATION_NOTHING_TO_CONFIRM = new BaseException("확정할 견적서가 없습니다.", 6001, 400);
        public static readonly BaseException QUOTATION_NOT_FOUND = new BaseException("해당 견적서를 찾을 수 없습니다.", 6002, 404);
        public static readonly BaseException QUOTATION_ACCESS_DENIED = new BaseException("해당 매칭 내역에 접근할 수 없습니다.", 6003, 403);
        public static readonly BaseException QUOTATION_ALREADY_CONFIRMED = new BaseException("견적서가 확정된 상태입니다.", 6004, 400);

        // 리뷰 7000
        public static readonly BaseException REVIEW_NOT_FOUND = new BaseException("해당 리뷰가 삭제되었거나 존재하지 않습니다.", 7001, 404);
        public static readonly BaseException REVIEW_EXIST = new BaseException("해당 매칭에 대한 리뷰가 이미 존재합니다.", 7002, 400);

        // 찜하기 8000
        public static readonly BaseException FAVORITE_ALREADY_EXISTS = new BaseException("이미 존재하는 찜하기 입니다.", 8001, 400);
        public static readonly BaseException FAVORITE_NOT_FOUND = new BaseException("존재하지 않는 찜하기 입니다.", 8002, 404);

        // 필드들
        public string Message { get; }
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
