/*
 * Библиотека для удобного доступа к базе данных 
 * Версия 0.4
 * История версий:
 * [0.4] Метод для обновления записей. 
 *       Свой класс для обработки исключений ExceptionWarning.
 * [0.3] Методы для удаления данных из базы данных.
 * [0.2] Метод для вставки новых элементов в базу данных.
 *       Вспомогательный класс для параметров.
 * [0.1] Первая версия. Содержит только запросы SELECT
 * 
 * Автор: Евгений Потребенко
 * Распостраняется по лицензии GPL
 * Все права принадлежат Евгению Потребенко (KreZ0n)
 */

using System;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace QuickVerbs
{
    class dbFacade
    {
        #region Настройки
        //путь к файлу базы
        public static string filename = Path.Combine(Application.StartupPath, "QuickVerbs.db");
        //строка подключения
        string ConnectionString = string.Format("data source={0};New=True;UseUTF16Encoding=True", filename);
        #endregion
        //--------------------------------------------------------------------------
        #region Создание базы
        /// <summary>
        /// Создать базу данных и таблицу
        /// </summary>
        public void CreateDatabase()
        {
            //SQL-запрос для таблицы
            string sql_test = @"CREATE TABLE 'Test'(
        'id' INTEGER PRIMARY KEY AUTOINCREMENT,
        'title' TEXT,
        'status' tinyint,
        'topic_id' INTEGER,
        'testdate' datetime NOT null DEFAULT '2009-10-07')";

            //SQL-запрос для индексации поля testdate
            string sql_createindex = "CREATE UNIQUE INDEX indx ON Test (id)";

            ConnectionState previousConnectionState = ConnectionState.Closed;
            using (SQLiteConnection connect = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    //проверяем предыдущее состояние
                    previousConnectionState = connect.State;
                    if (connect.State == ConnectionState.Closed)
                    {
                        //открываем соединение
                        connect.Open();
                    }
                    //создаем новую таблицу
                    SQLiteCommand command = new SQLiteCommand(sql_test, connect);
                    command.ExecuteNonQuery();

                    //создаем индексацию
                    command.CommandText = sql_createindex;
                    command.ExecuteNonQuery();
                }
                catch { }
                finally
                {
                    //закрываем соединение, если оно было закрыто перед открытием
                    if (previousConnectionState == ConnectionState.Closed)
                    {
                        connect.Close();
                    }
                }
            }
        }
        #endregion
        //--------------------------------------------------------------------------
        #region Получение данных
        /// <summary>
        /// Получить данные из таблицы
        /// </summary>
        /// <param name="databasename">Имя таблицы</param>
        /// <returns>Таблица с данными</returns>
        public DataTable FetchAll(string databasename, string columns)
        {
            return FetchAll(databasename, "", "", columns);
        }

        /// <summary>
        /// Получить данные из таблицы
        /// </summary>
        /// <param name="databasename">Имя таблицы</param>
        /// <param name="where">Условия</param>
        /// <returns>Таблица с данными</returns>
        public DataTable FetchAll(string databasename, string where, string columns)
        {
            return FetchAll(databasename, where, "", columns);
        }

        /// <summary>
        /// Получить данные из таблицы
        /// </summary>
        /// <param name="databasename">Имя таблицы</param>
        /// <param name="where">Условия</param>
        /// <param name="etc">Остальные параметры: сортировка, группировка и т.д.</param>
        /// <returns>Таблица с данными</returns>
        public DataTable FetchAll(string databasename, string where, string etc, string columns)
        {
            DataTable dt = new DataTable();
            string sql = string.Format("SELECT {3} FROM {0} {1} {2}", databasename, where, etc, columns);
            ConnectionState previousConnectionState = ConnectionState.Closed;
            using (SQLiteConnection connect = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    previousConnectionState = connect.State;
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }
                    SQLiteCommand command = new SQLiteCommand(sql, connect);
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    adapter.Fill(dt);
                }
                catch (Exception error)
                {
                    System.Windows.Forms.MessageBox.Show(error.Message, "Ошибка при получении данных из базы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                finally
                {
                    if (previousConnectionState == ConnectionState.Closed)
                    {
                        connect.Close();
                    }
                }
            }
            return dt;
        }
        //--------------------------------------------------------------------------
        /// <summary>
        /// Получение данных избирательно
        /// </summary>
        /// <param name="databasename">Имя базы данных</param>
        /// <param name="columns">Массив колонок, которые необходимо получить</param>
        /// <returns>Таблица с данными</returns>
        public DataTable FetchByColumn(string databasename, string[] columns)
        {
            return FetchByColumn(databasename, columns, "", "");
        }
        //--------------------------------------------------------------------------
        /// <summary>
        /// Получение данных избирательно
        /// </summary>
        /// <param name="databasename">Имя базы данных</param>
        /// <param name="columns">Массив колонок, которые необходимо получить</param>
        /// <param name="where">Условия</param>
        /// <returns>Таблица с данными</returns>
        public DataTable FetchByColumn(string databasename, string[] columns, string where)
        {
            return FetchByColumn(databasename, columns, where, "");
        }
        //--------------------------------------------------------------------------
        /// <summary>
        /// Получение данных избирательно
        /// </summary>
        /// <param name="databasename">Имя базы данных</param>
        /// <param name="columns">Массив колонок, которые необходимо получить</param>
        /// <param name="where">Условия</param>
        /// <param name="etc">Остальные параметры: сортировка, группировка и т.д.</param>
        /// <returns>Таблица с данными</returns>
        public DataTable FetchByColumn(string databasename, string[] columns, string where, string etc)
        {
            DataTable dt = new DataTable();
            string textofcolumns = string.Empty;

            if (columns == null || columns.Length == 0)
                textofcolumns = "*";
            else
            {
                bool ifFirst = true;
                //собираем все названия колонок в строку
                foreach (string col in columns)
                {
                    if (ifFirst)
                    {
                        textofcolumns = col;
                        ifFirst = false;
                    }
                    else
                        textofcolumns += "," + col;
                }
            }

            string sql = string.Format("SELECT {0} FROM {1} {2} {3}", textofcolumns, databasename, where, etc);
            ConnectionState previousConnectionState = ConnectionState.Closed;
            using (SQLiteConnection connect = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    previousConnectionState = connect.State;
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }
                    SQLiteCommand command = new SQLiteCommand(sql, connect);
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    adapter.Fill(dt);
                }
                catch (Exception error)
                {
                    System.Windows.Forms.MessageBox.Show(error.Message, "Ошибка при получении данных из базы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                finally
                {
                    if (previousConnectionState == ConnectionState.Closed)
                    {
                        connect.Close();
                    }
                }
            }
            return dt;
        }
        #endregion
        //--------------------------------------------------------------------------
        #region Вставка данных
        /// <summary>
        /// Вставка новых данных
        /// </summary>
        /// <param name="databasename">Имя базы данных</param>
        /// <param name="parameters">Коллекция параметров</param>
        public void Insert(string databasename, ParametersCollection parameters)
        {
            ConnectionState previousConnectionState = ConnectionState.Closed;
            using (SQLiteConnection connect = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    previousConnectionState = connect.State;
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }
                    SQLiteCommand command = new SQLiteCommand(connect);
                    bool ifFirst = true;
                    string queryColumns = "("; //список полей, в которые вставляются новые значения
                    string queryValues = "(";  //список значений для этих полей
                    foreach (Parameter iparam in parameters)
                    {
                        //добавляем новый параметр
                        command.Parameters.Add("@" + iparam.ColumnName, iparam.DbType).Value = iparam.Value;
                        //собираем колонки и значения в одну строку
                        if (ifFirst)
                        {
                            queryColumns += iparam.ColumnName;
                            queryValues += "@" + iparam.ColumnName;
                            ifFirst = false;
                        }
                        else
                        {
                            queryColumns += "," + iparam.ColumnName;
                            queryValues += ",@" + iparam.ColumnName;
                        }
                    }
                    queryColumns += ")";
                    queryValues += ")";
                    //создаем новый запрос
                    string sql = string.Format("INSERT INTO {0} {1} VALUES {2}", databasename, queryColumns, queryValues);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    System.Windows.Forms.MessageBox.Show(error.Message, "Ошибка при вставке нового значения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (previousConnectionState == ConnectionState.Closed)
                    {
                        connect.Close();
                    }
                }
            }
        }
        #endregion
        //--------------------------------------------------------------------------
        #region Удаление данных
        /// <summary>
        /// Удаление всех данных в заданой таблице
        /// </summary>
        /// <param name="tablename">Имя таблицы</param>
        public int Delete(string tablename)
        {
            string sql = string.Format("DELETE FROM {0}", tablename);
            ConnectionState previousConnectionState = ConnectionState.Closed;
            using (SQLiteConnection connect = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    previousConnectionState = connect.State;
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }
                    SQLiteCommand command = new SQLiteCommand(sql, connect);
                    command.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    System.Windows.Forms.MessageBox.Show(error.Message, "Ошибка при удалении данных из таблицы " + tablename, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 1;
                }
                finally
                {
                    if (previousConnectionState == ConnectionState.Closed)
                    {
                        connect.Close();
                    }
                }
            }
            return 0;
        }
        //--------------------------------------------------------------------------
        /// <summary>
        /// Удаление с условием
        /// </summary>
        /// <param name="tablename">Имя таблицы</param>
        /// <param name="where">Условия</param>
        public int Delete(string tablename, string where)
        {
            string sql = string.Format("DELETE FROM {0} {1}", tablename, where);
            ConnectionState previousConnectionState = ConnectionState.Closed;
            using (SQLiteConnection connect = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    previousConnectionState = connect.State;
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }
                    SQLiteCommand command = new SQLiteCommand(sql, connect);
                    command.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    System.Windows.Forms.MessageBox.Show(error.Message, "Ошибка при удалении данных из таблицы " + tablename, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 1;
                }
                finally
                {
                    if (previousConnectionState == ConnectionState.Closed)
                    {
                        connect.Close();
                    }
                }
            }
            return 0;
        }
        //--------------------------------------------------------------------------
        /// <summary>
        /// Удаление с массивом условий
        /// </summary>
        /// <param name="tablename">Имя таблицы</param>
        /// <param name="column">Название поля</param>
        /// <param name="collection">Массив объектов с условием</param>
        public int Delete(string tablename, string column, object[] collection)
        {
            ConnectionState previousConnectionState = ConnectionState.Closed;
            using (SQLiteConnection connect = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    previousConnectionState = connect.State;
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }
                    #region Создаем строку условий
                    bool ifFirst = true;
                    string where = string.Empty;
                    foreach (object item in collection)
                    {
                        if (ifFirst)
                        {
                            where = "WHERE " + column + " = '" + item + "'";
                            ifFirst = false;
                        }
                        else
                        {
                            where += " OR " + column + " = '" + item + "'";
                        }
                    }
                    #endregion

                    string sql = string.Format("DELETE FROM {0} {1}", tablename, where);
                    SQLiteCommand command = new SQLiteCommand(sql, connect);
                    command.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    System.Windows.Forms.MessageBox.Show(error.Message, "Ошибка при удалении данных из таблицы " + tablename, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 1;
                }
                finally
                {
                    if (previousConnectionState == ConnectionState.Closed)
                    {
                        connect.Close();
                    }
                }
                return 0;
            }
        }
        #endregion
        //--------------------------------------------------------------------------
        #region Обновление данных
        /// <summary>
        /// Обновление данных
        /// </summary>
        /// <param name="tablename">Имя таблицы</param>
        /// <param name="collection">Коллекция полей и значений</param>
        /// <param name="whereparams">Набор условий</param>
        /// <param name="whereseparator">Разделитель между условиями OR или AND</param>
        public void Update(string tablename, ParametersCollection collection, object[] whereparams, string whereseparator)
        {
            ConnectionState previousConnectionState = ConnectionState.Closed;
            using (SQLiteConnection connect = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    //проверяем переданные аргументы
                    if (whereparams.Length == 0) throw (new ExceptionWarning("Ошибка! Не указано ни одно условие"));
                    if (whereparams.Length > 0 && whereseparator.Trim().Length == 0) throw (new ExceptionWarning("При использовании нескольких условий, требуется указать разделитель OR или AND"));

                    previousConnectionState = connect.State;
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }

                    int i = 0;
                    //готовим переменную для сбора полей и их значений
                    string sql_params = string.Empty;
                    bool ifFirst = true;
                    SQLiteCommand command = new SQLiteCommand(connect);
                    //в цикле создаем строку запроса 
                    foreach (Parameter param in collection)
                    {
                        if (ifFirst)
                        {
                            sql_params = param.ColumnName + " = @param" + i;
                            ifFirst = false;
                        }
                        else
                        {
                            sql_params += "," + param.ColumnName + " = @param" + i;
                        }
                        //и добавляем параметры с таким же названием
                        command.Parameters.Add("@param" + i, param.DbType).Value = param.Value;
                        i++;
                    }

                    //условия для запроса
                    string sql_where = string.Empty;
                    ifFirst = true;
                    //собираем строку с условиями
                    foreach (object item in whereparams)
                    {
                        if (ifFirst)
                        {
                            sql_where = item.ToString();
                            ifFirst = false;
                        }
                        else
                        {
                            sql_where += " " + whereseparator + " " + item;
                        }
                    }
                    sql_where = "WHERE " + sql_where;
                    //собираем запрос воедино
                    command.CommandText = string.Format("UPDATE {0} SET {1} {2}", tablename, sql_params, sql_where);
                    //выполняем запрос
                    command.ExecuteNonQuery();
                }
                catch (ExceptionWarning message)
                {
                    System.Windows.Forms.MessageBox.Show(message.MessageText, "Ошибка при обновлении данных в таблице " + tablename, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception error)
                {
                    System.Windows.Forms.MessageBox.Show(error.Message, "Ошибка при обновлении данных в таблице " + tablename, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (previousConnectionState == ConnectionState.Closed)
                    {
                        connect.Close();
                    }
                }
            }
        }
        #endregion
    }
    //--------------------------------------------------------------------------
    #region Параметры
    /// <summary>
    /// Класс для передачи параметра
    /// </summary>
    class Parameter
    {
        #region Поля
        string _columnName;
        object _value;
        DbType _dbType;
        #endregion

        /// <summary>
        /// Значение
        /// </summary>
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        /// Название поля в базе данных
        /// </summary>
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        /// <summary>
        /// Тип передаваемого значения
        /// </summary>
        public DbType DbType
        {
            get { return _dbType; }
            set { _dbType = value; }
        }
    }
    //--------------------------------------------------------------------------
    /// <summary>
    /// Коллекция параметров
    /// </summary>
    class ParametersCollection : CollectionBase
    {
        /// <summary>
        /// Добавить параметр в коллекцию
        /// </summary>
        /// <param name="iparam">Новый параметр</param>
        public virtual void Add(Parameter iparam)
        {
            //добавляем в общую коллекцию
            this.List.Add(iparam);
        }

        /// <summary>
        /// Добавить параметр в коллекцию
        /// </summary>
        /// <param name="columnName">Имя поля/колонки</param>
        /// <param name="value">Значине</param>
        /// <param name="dbType">Тип значения</param>
        public virtual void Add(string columnName, object value, DbType dbType)
        {
            //Инициализируем объект с параметром
            Parameter iparam = new Parameter();
            //присваиваем название поля
            iparam.ColumnName = columnName;
            //присваиваем значение
            iparam.Value = value;
            //присваиваем тип значения
            iparam.DbType = dbType;
            //добавляем в общую коллекцию
            //List описан в "родителе"
            this.List.Add(iparam);
        }

        /// <summary>
        /// Получить элемент по индексу
        /// </summary>
        /// <param name="Index">Индекс</param>
        /// <returns>Параметр</returns>
        public virtual Parameter this[int Index]
        {
            get
            {
                //возвращает элемент по индексу
                //используется в конструкции foreach
                return (Parameter)this.List[Index];
            }
        }
    }
    #endregion
    //--------------------------------------------------------------------------
    #region Класс исключений
    class ExceptionWarning : Exception
    {
        private string _messageText;

        public string MessageText
        {
            get { return _messageText; }
        }

        public ExceptionWarning(string messagetext)
            : base()
        {
            _messageText = messagetext;
        }
    }
    #endregion
    //--------------------------------------------------------------------------
}
