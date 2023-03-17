using TDD.CleanArchitecture.Repository;

namespace TDD.CleanArchitecture.Service
{
    public class ApplyScholarshipService : IApplyScholarshipService
    {
        IStudentRepository _studentRepository;

        public ApplyScholarshipService()
        {
        
        }

        public ApplyScholarshipService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }   

        public void Apply(ApplicationForm applicationForm)
        {           
            //調閱學生資料
            //調閱獎學金規定的資料
            //查驗是否符合資格
            //填寫正式申請書
            //存檔
        }
    }
}
