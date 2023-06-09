using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*会议记录业务逻辑层*/
    public class bllMeeting{
        /*添加会议记录*/
        public static bool AddMeeting(ENTITY.Meeting meeting)
        {
            return DAL.dalMeeting.AddMeeting(meeting);
        }

        /*根据meetingId获取某条会议记录记录*/
        public static ENTITY.Meeting getSomeMeeting(int meetingId)
        {
            return DAL.dalMeeting.getSomeMeeting(meetingId);
        }

        /*更新会议记录*/
        public static bool EditMeeting(ENTITY.Meeting meeting)
        {
            return DAL.dalMeeting.EditMeeting(meeting);
        }

        /*删除会议记录*/
        public static bool DelMeeting(string p)
        {
            return DAL.dalMeeting.DelMeeting(p);
        }

        /*查询会议记录*/
        public static System.Data.DataSet GetMeeting(string strWhere)
        {
            return DAL.dalMeeting.GetMeeting(strWhere);
        }

        /*根据条件分页查询会议记录*/
        public static System.Data.DataTable GetMeeting(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalMeeting.GetMeeting(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的会议记录*/
        public static System.Data.DataSet getAllMeeting()
        {
            return DAL.dalMeeting.getAllMeeting();
        }
    }
}
