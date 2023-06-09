using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*成绩业务逻辑层*/
    public class bllScore{
        /*添加成绩*/
        public static bool AddScore(ENTITY.Score score)
        {
            return DAL.dalScore.AddScore(score);
        }

        /*根据scoreId获取某条成绩记录*/
        public static ENTITY.Score getSomeScore(int scoreId)
        {
            return DAL.dalScore.getSomeScore(scoreId);
        }

        /*更新成绩*/
        public static bool EditScore(ENTITY.Score score)
        {
            return DAL.dalScore.EditScore(score);
        }

        /*删除成绩*/
        public static bool DelScore(string p)
        {
            return DAL.dalScore.DelScore(p);
        }

        /*查询成绩*/
        public static System.Data.DataSet GetScore(string strWhere)
        {
            return DAL.dalScore.GetScore(strWhere);
        }

        /*根据条件分页查询成绩*/
        public static System.Data.DataTable GetScore(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalScore.GetScore(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的成绩*/
        public static System.Data.DataSet getAllScore()
        {
            return DAL.dalScore.getAllScore();
        }
    }
}
