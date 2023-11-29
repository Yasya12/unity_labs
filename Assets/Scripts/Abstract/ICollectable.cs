using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Abstract
{
	internal interface ICollectable
	{
		void Initialize(Action onCollect, Action onNotCollect);

		void Collect();
		void OnNotCollect();
	}
}
