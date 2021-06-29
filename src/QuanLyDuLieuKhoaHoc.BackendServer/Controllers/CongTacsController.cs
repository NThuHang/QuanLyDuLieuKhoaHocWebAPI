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
    public class CongTacsController : ControllerBase
    {
        private ICongTacBLL _CongTacBLL;
        public CongTacsController(ICongTacBLL CongTacBLL)
        {
            _CongTacBLL = CongTacBLL;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<CongTacModel> GetDataAll()
        {
            return _CongTacBLL.GetData();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public CongTacModel GetDatabyID(string id)
        {
            return _CongTacBLL.GetDatabyID(id);
        }

        [Route("get-a/{id}")]
        [HttpGet]
        public CongTacModel GetDatabyGV(string id)
        {
            return _CongTacBLL.GetDatabyGV(id);
        }

        [Route("create-CongTac")]
        [HttpPost]
        public CongTacModel CreateItem([FromBody] CongTacModel model)
        {
            _CongTacBLL.Create(model);
            return model;
        }

        [Route("delete-CongTac")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            int id = 0;
            if (formData.Keys.Contains("id") && Convert.ToInt32(formData["id"].ToString())>0)
            { id = Convert.ToInt32(formData["id"].ToString()); }
            _CongTacBLL.Delete(id);
            return Ok();
        }

        [Route("update-CongTac")]
        [HttpPost]
        public CongTacModel UpdateUser([FromBody] CongTacModel model)
        {
            _CongTacBLL.Update(model);
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
                string idGV = Convert.ToString(formData["idGV"]);
                string ten = "";
                if (formData.Keys.Contains("ten") && !string.IsNullOrEmpty(Convert.ToString(formData["ten"])))
                {
                    ten = Convert.ToString(formData["ten"]);
                }
                long total = 0;
                var data = _CongTacBLL.Search(page, pageSize, out total, ten, idGV);
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

        [Route("get-gv/{id}")]
        [HttpGet]
        public List<CongTacModel> GetGV(string id)
        {
            return _CongTacBLL.GetGV(id);
        }

    }
}
