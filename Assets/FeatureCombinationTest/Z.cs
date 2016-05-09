using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Feature3
{
    public enum Type
    {
        Red,
        Blue,
    }

    /// <summary>
    /// クラスをまとめるヘルパー
    /// </summary>
    public static class Strategies
    {
        /// <summary>中身</summary>
        public static List<IStrategy> types = new List<IStrategy>();

        /// <summary>static ctor</summary>
        static Strategies()
        {
            // 特定のインターフェースを実装するクラスを全てインスタンス化する処理
            // これらのロジックは以下のリンクを参考にしています
            // http://stackoverflow.com/questions/26733/getting-all-types-that-implement-an-interface answer of Ben Watkins, and comment of TamusJRoyce
            // http://stackoverflow.com/questions/752/get-a-new-object-instance-from-a-type


            var alltypes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(x => x.GetInterfaces().Contains(typeof(IStrategy)));
            alltypes.ToList().ForEach(x => types.Add(Activator.CreateInstance(x) as IStrategy));
        }
    }

    public interface IStrategy
    {
        GameObject A3();
    }

    public class Red : IStrategy
    {
        public GameObject A3()
        {
            Debug.Log("Feature3:Red");
            return new GameObject();
        }
    }

    public class Blue : IStrategy
    {
        public GameObject A3()
        {
            Debug.Log("Feature3:Blue");
            return new GameObject();
        }
    }
}