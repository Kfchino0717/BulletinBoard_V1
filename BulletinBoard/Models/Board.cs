namespace BulletinBoard.Models
{
    /// <summary>
    /// 留言板
    /// </summary>
    public class Board
    {
        /// <summary>
        /// 流水編號
        /// </summary>
        public int Id {  get; set; }

        /// <summary>
        /// 貼文標題
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 貼文內容
        /// </summary>
        public string? Description { get; set; }
    }
}
