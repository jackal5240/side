namespace side.Interface
{
    public interface IConnStrSingleton
    {
        /// <summary>
        /// 設定資料庫連線字串。
        /// </summary>
        /// <param name="connectionString">與資料庫的連線字串。</param>
        void SetConnectionString(string connectionString);
    }
}
