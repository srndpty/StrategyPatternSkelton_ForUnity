using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Feature2
{
    public enum Type
    {
        First,
        Second,
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
            // http://stackoverflow.com/questions/26733/getting-all-types-that-implement-an-interface (answer of Ben Watkins, and comment of TamusJRoyce)
            // http://stackoverflow.com/questions/752/get-a-new-object-instance-from-a-type


            var alltypes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(x => x.GetInterfaces().Contains(typeof(IStrategy)));
            alltypes.ToList().ForEach(x => types.Add(Activator.CreateInstance(x) as IStrategy));
        }
    }

    public interface IStrategy
    {
        IEnumerator A2();
    }

    public class First : IStrategy
    {
        public IEnumerator A2()
        {
            yield return null;
            Debug.Log("Feature2:First");
        }
    }

    public class Second : IStrategy
    {
        public IEnumerator A2()
        {
            yield return null;
            Debug.Log("Feature2:Second");
        }
    }
}