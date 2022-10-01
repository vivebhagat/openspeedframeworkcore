using CSScriptLibrary;

namespace SpeedFramework.DAO.BAL.Scripting
{
    public class ScriptEngine
    {
        public static dynamic Execute(dynamic o, string _script)
        {
            var exec_method = CSScript.CreateFunc<object>(_script);
            var result = exec_method(o);
            return result;
        }
    }
}
