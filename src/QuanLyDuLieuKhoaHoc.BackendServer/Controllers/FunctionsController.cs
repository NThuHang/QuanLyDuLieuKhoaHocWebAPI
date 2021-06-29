using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyDuLieuKhoaHoc.BLL;
using QuanLyDuLieuKhoaHoc.Model;

namespace QuanLyDuLieuKhoaHoc.BackendServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionsController : ControllerBase
    {
        private IFunctionBLL _FunctionBLL;
        public FunctionsController(IFunctionBLL FunctionBLL)
        {
            _FunctionBLL = FunctionBLL;
        }

        [Route("get-all/{id}")]
        [HttpGet]
        public IEnumerable<FunctionModel> GetDatabAll(string id)
        {
            return _FunctionBLL.GetData(id);
        }
    }
}
