using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLyDuLieuKhoaHoc.BLL;
using QuanLyDuLieuKhoaHoc.Model;

namespace QuanLyDuLieuKhoaHoc.BackendServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoMonsController : ControllerBase
    {
        private IBoMonBLL _BoMonBLL;
        public BoMonsController(IBoMonBLL BoMonBLL)
        {
            _BoMonBLL = BoMonBLL;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<BoMonModel> GetDataAll()
        {
            return _BoMonBLL.GetData();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public BoMonModel GetDatabyID(string id)
        {
            return _BoMonBLL.GetDatabyID(id);
        }

        [Route("create-BoMon")]
        [HttpPost]
        public BoMonModel CreateItem([FromBody] BoMonModel model)
        {
            model.Id = Guid.NewGuid().ToString();
            _BoMonBLL.Create(model);
            return model;
        }

        [Route("delete-BoMon")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string Id = "";
            if (formData.Keys.Contains("Id") && !string.IsNullOrEmpty(Convert.ToString(formData["Id"]))) 
            { Id = Convert.ToString(formData["Id"]); }
            _BoMonBLL.Delete(Id);
            return Ok();
        }

        [Route("update-BoMon")]
        [HttpPost]
        public BoMonModel UpdateUser([FromBody] BoMonModel model)
        {
            _BoMonBLL.Update(model);
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
                var data = _BoMonBLL.Search(page, pageSize, out total, ten);
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

        [Route("getKhoa/{id}")]
        [HttpGet]
        public List<BoMonModel> GetKhoa(string id)
        {
            return _BoMonBLL.GetKhoa(id);
        }
    }
}
