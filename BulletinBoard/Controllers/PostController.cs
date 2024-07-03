using BulletinBoard.Models;
using BulletinBoard.Parameter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

//沒有用到DB資料庫

namespace BulletinBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private static List<Board> _boards = new List<Board>();

        // GET: api/<PostController>
        /// <summary>
        /// 查詢留言列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Board>> GetList()
        {
            return Ok(_boards);
        }

        // GET api/<PostController>/5
        /// <summary>
        /// 查詢單筆留言
        /// </summary>
        /// <param name="id">留言編號</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Board> Get([FromRoute] int id)
        {
            var board = _boards.FirstOrDefault(b => b.Id == id);
            if (board == null)
            {
                return NotFound();
            }
            return Ok(board);
        }

        /// <summary>
        /// 新增留言
        /// </summary>
        /// <param name="parameter">流水編號</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insert([FromBody] BoardParameter parameter)
        {
            var newId = _boards.Any() ? _boards.Max(board => board.Id) + 1 : 1;
            _boards.Add(new Board
            {
                Id = newId,
                Name = parameter.Name,
                Description = parameter.Description,
            });

            return Ok();
        }

        /// <summary>
        /// 更新留言
        /// </summary>
        /// <param name="id">留言編號</param>
        /// <param name="parameter">更新內容</param>
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] BoardParameter parameter)
        {
            var targetBoard = _boards.FirstOrDefault(board => board.Id == id);
            if (targetBoard == null)
            {
                return NotFound();
            }

            targetBoard.Name = parameter.Name;
            targetBoard.Description = parameter.Description;

            return Ok();
        }
        /// <summary>
        /// 刪除單筆留言
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var count = _boards.RemoveAll(board => board.Id == id);
            if (count == 0)
            {
                return NotFound();
            }
            ///當刪除時Id不會回復刪除的編號 刪掉就不能再增加被刪除的編號
            Delete(id);
            return NoContent();
        }
    }
}
