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
    public class GiangViensController : ControllerBase
    {
        private IGiangVienBLL _giangVienBLL;
        private string _path;
        public GiangViensController(IGiangVienBLL giangVienBLL, IConfiguration configuration)
        {
            _giangVienBLL = giangVienBLL;
            _path = configuration["AppSettings:PATH"];
        }
        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }
        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<GiangVienModel> GetDataAll()
        {
            return _giangVienBLL.GetData();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public GiangVienModel GetDatabyID(string id)
        {
            return _giangVienBLL.GetDatabyID(id);
        }

        [Route("create-gv")]
        [HttpPost]
        public GiangVienModel CreateGV([FromBody] GiangVienModel model)
        {
            if (model.HinhAnh != null)
            {
                var arrData = model.HinhAnh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/hinhanh/{arrData[0]}";
                    model.HinhAnh = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            model.Id = Guid.NewGuid().ToString();
            _giangVienBLL.Create(model);
            return model;
        }

        [Route("delete-gv")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string id = "";
            if (formData.Keys.Contains("id")
                && !string.IsNullOrEmpty(Convert.ToString(formData["id"])))
            { id = Convert.ToString(formData["id"]); }
            _giangVienBLL.Delete(id);
            return Ok();
        }

        [Route("update-gv")]
        [HttpPost]
        public GiangVienModel UpdateUser([FromBody] GiangVienModel model)
        {
            if (model.HinhAnh != null)
            {
                var arrData = model.HinhAnh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/hinhanh/{arrData[0]}";
                    model.HinhAnh = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            else
            {
                model.HinhAnh = model.HinhAnh;
            }
            _giangVienBLL.Update(model);
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
                string hoten = "";
                if (formData.Keys.Contains("hoten") && !string.IsNullOrEmpty(Convert.ToString(formData["hoten"])))
                {
                    hoten = Convert.ToString(formData["hoten"]);
                }
                long total = 0;
                var data = _giangVienBLL.Search(page, pageSize, out total, hoten);
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

        [Route("get-thongtin/{id}")]
        [HttpGet]
        public GiangVienModel Get_ThongTin_TK(string id)
        {
            return _giangVienBLL.Get_ThongTin_TK(id);
        }

        [Route("giangvien-co-detai")]
        [HttpGet]
        public IEnumerable<GiangVienModel> GetGV_DeTaiAll()
        {
            return _giangVienBLL.GetGV_DeTai();
        }

        [Route("giangvien-co-sach")]
        [HttpGet]
        public IEnumerable<GiangVienModel> GetGV_Sach()
        {
            return _giangVienBLL.GetGV_Sach();
        }

        [Route("giangvien-co-baochi")]
        [HttpGet]
        public IEnumerable<GiangVienModel> GetGV_BBao()
        {
            return _giangVienBLL.GetGV_BBao();
        }

        [Route("tongsl")]
        [HttpGet]
        public int laytong()
        {
            return _giangVienBLL.GetTong();
        }

    }
}
