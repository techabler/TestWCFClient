using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DetectIdleTime
{
    /// <summary>
    /// 참조 : https://icodebroker.tistory.com/entry/CWINFORM-%EC%82%AC%EC%9A%A9%EC%9E%90-%EB%B9%84%ED%99%9C%EC%84%B1-%EA%B0%90%EC%A7%80%ED%95%98%EA%B8%B0
    ///         https://learn.microsoft.com/ko-kr/windows/win32/api/winuser/nf-winuser-getlastinputinfo
    ///         https://learn.microsoft.com/ko-kr/windows/win32/api/winuser/ns-winuser-lastinputinfo
    ///         https://learn.microsoft.com/ko-kr/windows/win32/api/sysinfoapi/nf-sysinfoapi-gettickcount64
    ///         https://stackoverflow.com/questions/13210142/how-do-i-determine-idle-time-in-my-c-sharp-application (최종 참조)
    ///         
    /// </summary>
    public class InactiveDetector
    {
        // C# Win32 API 함수를 사용할 수 있도록 : 사용자 입력 마지막 Tick값 가져오기 
        [DllImport("user32")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFORMATION inputInfo);
        
        // 64bit변경 시 문제점 : LASTINPUTINFORMATION의 TickCount는 32bit라 시작 tickCount가 변경됨 - 비교할 수 없음
        //[DllImport("kernel32")]
        //private static extern UInt64 GetTickCount64();

        public TimeSpan? GetInactiveIdleTime()
        {
            LASTINPUTINFORMATION inputInfo = new LASTINPUTINFORMATION();
            inputInfo.Size = (uint)Marshal.SizeOf(inputInfo);

            // 사용자 input last event tick time 
            if (GetLastInputInfo(ref inputInfo))
            {

                TimeSpan t = TimeSpan.FromMilliseconds(Environment.TickCount);
                Log.Debug("Environment TickCount:{a} - UserInput TickCount:{b} = {c} [{d}]", Environment.TickCount, inputInfo.Time, Environment.TickCount - inputInfo.Time
                    , string.Format("{0:D2}d {1:D2}h:{2:D2}m:{3:D2}s-{4:D3}mil", t.Days, t.Hours, t.Minutes, t.Seconds, t.Milliseconds));

                TimeSpan inT = TimeSpan.FromMilliseconds(inputInfo.Time);
                Log.Debug("Environment TickCount:{a} - UserInput TickCount:{b} = {c} [{d}]", (uint)Environment.TickCount, inputInfo.Time, (uint)Environment.TickCount - inputInfo.Time
                    , string.Format("{0:D2}d {1:D2}h:{2:D2}m:{3:D2}s-{4:D3}mil", inT.Days, inT.Hours, inT.Minutes, inT.Seconds, inT.Milliseconds));

                
                //return TimeSpan.FromMilliseconds(Environment.TickCount - inputInfo.Time);
                // Environment.TickCount도 uint로 변환하여 49일 이후는 동일한 시점에서 TickCount 시작하면 유휴타임 계산 가능
                return TimeSpan.FromMilliseconds((uint)Environment.TickCount - inputInfo.Time);
            }
            else
            {
                return null;
            }
        }



        [StructLayout(LayoutKind.Sequential)]
        internal struct LASTINPUTINFORMATION
        {
            /// <summary>
            /// 구조체 크기(Byte)
            /// </summary>
            public uint Size;
            /// <summary>
            /// 마지막 입력 event가 수신된 Tick Count
            /// </summary>
            public uint Time;
        }
    }
}
