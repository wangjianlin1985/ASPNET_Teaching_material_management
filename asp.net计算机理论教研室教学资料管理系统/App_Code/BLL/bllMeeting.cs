using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�����¼ҵ���߼���*/
    public class bllMeeting{
        /*��ӻ����¼*/
        public static bool AddMeeting(ENTITY.Meeting meeting)
        {
            return DAL.dalMeeting.AddMeeting(meeting);
        }

        /*����meetingId��ȡĳ�������¼��¼*/
        public static ENTITY.Meeting getSomeMeeting(int meetingId)
        {
            return DAL.dalMeeting.getSomeMeeting(meetingId);
        }

        /*���»����¼*/
        public static bool EditMeeting(ENTITY.Meeting meeting)
        {
            return DAL.dalMeeting.EditMeeting(meeting);
        }

        /*ɾ�������¼*/
        public static bool DelMeeting(string p)
        {
            return DAL.dalMeeting.DelMeeting(p);
        }

        /*��ѯ�����¼*/
        public static System.Data.DataSet GetMeeting(string strWhere)
        {
            return DAL.dalMeeting.GetMeeting(strWhere);
        }

        /*����������ҳ��ѯ�����¼*/
        public static System.Data.DataTable GetMeeting(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalMeeting.GetMeeting(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĻ����¼*/
        public static System.Data.DataSet getAllMeeting()
        {
            return DAL.dalMeeting.getAllMeeting();
        }
    }
}
