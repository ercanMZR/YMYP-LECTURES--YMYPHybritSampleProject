using Microsoft.AspNetCore.Mvc;
using YMYPHybritSampleProject.Model.Services;

namespace YMYPHybritSampleProject.Controllers
{
    public class CustomControllerBase:ControllerBase
    {
        public void x<T>(ServiceResult<T> serviceResult)
        {

        }
    }
}
