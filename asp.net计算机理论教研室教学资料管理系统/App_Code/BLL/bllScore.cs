using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�ɼ�ҵ���߼���*/
    public class bllScore{
        /*��ӳɼ�*/
        public static bool AddScore(ENTITY.Score score)
        {
            return DAL.dalScore.AddScore(score);
        }

        /*����scoreId��ȡĳ���ɼ���¼*/
        public static ENTITY.Score getSomeScore(int scoreId)
        {
            return DAL.dalScore.getSomeScore(scoreId);
        }

        /*���³ɼ�*/
        public static bool EditScore(ENTITY.Score score)
        {
            return DAL.dalScore.EditScore(score);
        }

        /*ɾ���ɼ�*/
        public static bool DelScore(string p)
        {
            return DAL.dalScore.DelScore(p);
        }

        /*��ѯ�ɼ�*/
        public static System.Data.DataSet GetScore(string strWhere)
        {
            return DAL.dalScore.GetScore(strWhere);
        }

        /*����������ҳ��ѯ�ɼ�*/
        public static System.Data.DataTable GetScore(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalScore.GetScore(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĳɼ�*/
        public static System.Data.DataSet getAllScore()
        {
            return DAL.dalScore.getAllScore();
        }
    }
}
