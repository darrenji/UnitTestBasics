using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace ThirdDemo.Tests
{
    public class JsonFileDataAttribute : DataAttribute
    {
        private readonly string _filePath;
        private readonly string _propertyName;

        public JsonFileDataAttribute(string filePath) : this(filePath, null)
        {

        }

        public JsonFileDataAttribute(string filePath, string propertyName)
        {
            _filePath = filePath;
            _propertyName = propertyName;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if(testMethod==null)
            {
                throw new ArgumentNullException(nameof(testMethod));
            }

            //确定路径
            var path = Path.IsPathRooted(_filePath) ? _filePath : Path.GetRelativePath(Directory.GetCurrentDirectory(), _filePath);

            if(!File.Exists(path)) //文件是否存在
            {
                throw new ArgumentException($"Could not find file at path: {path}");
            }

            var fileData = File.ReadAllText(_filePath);

            if(string.IsNullOrEmpty(_propertyName))//如果不从属性中获取
            {
                //反序列化成类
                return JsonConvert.DeserializeObject<List<object[]>>(fileData);
            }

            //从某个属性获取
            var allData = JObject.Parse(fileData);
            var data = allData[_propertyName];
            return data.ToObject<List<object[]>>();
        }
    }
}
