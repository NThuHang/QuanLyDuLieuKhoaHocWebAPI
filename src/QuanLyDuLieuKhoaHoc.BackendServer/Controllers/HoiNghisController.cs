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
    public class HoiNghisController : ControllerBase
    {
        private IHoiNghiBLL _HoiNghiBLL;
        public HoiNghisController(IHoiNghiBLL HoiNghiBLL)
        {
            _HoiNghiBLL = HoiNghiBLL;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<HoiNghiModel> GetDataAll()
        {
            return _HoiNghiBLL.GetData();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public HoiNghiModel GetDatabyID(string id)
        {
            return _HoiNghiBLL.GetDatabyID(id);
        }

        [Route("create-HoiNghi")]
        [HttpPost]
        public HoiNghiModel CreateItem([FromBody] HoiNghiModel model)
        {
            _HoiNghiBLL.Create(model);
            return model;
        }

        [Route("delete-HoiNghi")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string bc_id = "";
            if (formData.Keys.Contains("bc_id") && !string.IsNullOrEmpty(Convert.ToString(formData["bc_id"]))) { bc_id = Convert.ToString(formData["bc_id"]); }
            _HoiNghiBLL.Delete(bc_id);
            return Ok();
        }

        [Route("update-HoiNghi")]
        [HttpPost]
        public HoiNghiModel UpdateUser([FromBody] HoiNghiModel model)
        {
            _HoiNghiBLL.Update(model);
            return model;
        }

        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten = "";
                if (formData.Keys.Contains("ten") && !string.IsNullOrEmpty(Convert.ToString(formData["ten"])))
                {
                    ten = Convert.ToString(formData["ten"]);
                }
                long total = 0;
                var data = _HoiNghiBLL.Search(page, pageSize, out total, ten);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

        [Route("tongsl")]
        [HttpGet]
        public int laytong()
        {
            return _HoiNghiBLL.GetTong();
        }
    }
}
