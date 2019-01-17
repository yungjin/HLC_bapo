using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Select
    {
        public ArrayList SelectMa()
        {
            WebClient client = new WebClient(); // 웹 접속 객체 생성
            NameValueCollection data = new NameValueCollection(); // 파라메터값 담을 객체 생성 

            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)"); // 웹 호출 시 보낸쪽 정보 설정
            client.Encoding = Encoding.UTF8; // UTF-8 설정 하여 한글 처리하기

            string url = "http://192.168.3.25:5000/api/Select"; // 웹 호출 주소 정의하기
            string method = "POST"; // 웹 호출 시 통신 방식 정의하기

            byte[] result = client.UploadValues(url, method, data);
            string strResult = Encoding.UTF8.GetString(result);

            ArrayList jList = JsonConvert.DeserializeObject<ArrayList>(strResult); // JSON 데이터 변경
            ArrayList list = new ArrayList(); // JSON 에서 LIST로 담을 객체 생성            
            foreach (JObject row in jList) // JSON 데이터에서 key : value 형식으로 분리하기
            {
                Hashtable ht = new Hashtable(); // Key : Value 형식으로 데이터 담을 객체 생성
                foreach (JProperty col in row.Properties()) // JSON 속성(키값) 가져오기
                {
                    ht.Add(col.Name, col.Value); // Key : Value 형식으로 데이터 담기
                }

                list.Add(ht); // JSON 에서 LIST 로 데이터 담기
            }
            
            return list;
        }
    }
}
