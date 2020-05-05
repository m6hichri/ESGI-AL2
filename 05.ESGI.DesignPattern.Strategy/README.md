﻿﻿# Strategy

Imaginons le code suivant

```
public class SortListHelper
{
	public List<T> Sort<T>(List<T> list) { /* Trie par tas */ return list; }
}
```

Nous l'utilisons partout dans le code de la manière suivante

```
var sortListHelper = new SortListHelper();

var list = new List<string> { "Mickael", "Nicolas" };

var sortedList = sortListHelper.Sort(list);
```

Après quelques temps, il nous est demandé d'implémeter une nouvelle stratégie de tri (tri rapide) et nous créeons donc le code suivant

```
public class SortListHelper
{
	public List<T> HeapSort<T>(List<T> list) { /* Tri par tas */ return list; }
	public List<T> QuickSort<T>(List<T> list) { /* Tri rapide */ return list; }
}
```

Encore après quelques temps, il nous est demandé d'implémeter une nouvelle stratégie de tri (tri à bulle) et nous créeons donc le code suivant

```
public class SortListHelper
{
	public List<T> HeapSort<T>(List<T> list) { /* Tri par tas */ return list; }
	public List<T> QuickSort<T>(List<T> list) { /* Tri rapide */ return list; }
	public List<T> BubbleSort<T>(List<T> list) { /* Tri à bulle */ return list; }
}
```

Finalement nous nous rendons compte que cette classe fait toujours la meme chose (un tri) mais de multiple manière. Nous pourrions donc déléguer la manière de faire à des classes spécialisées

```
public abstract class SortStrategy
{
	public abstract List<T> Sort<T>(List<T> list);
}

public class HeapSortStrategy
{
	public override List<T> Sort<T>(List<T> list) { /* Tri par tas */ return list; }
}

public class QuickSortStrategy
{
	public override List<T> Sort<T>(List<T> list) { /* Tri rapide */ return list; }
}

public class BubbleSortStrategy
{
	public override List<T> Sort<T>(List<T> list) { /* Tri à bulle */ return list; }
}
```

Maintenant il nous suffit de modifier la classe SortListHelper afin de pouvoir prendre différent type de comportement (SortStrategy) et de les appliquer

```
public class SortListHelper
{
	private SortStrategy _sortStrategy;

	public SortListHelper(SortStrategy sortStrategy)
	{
		_sortStrategy = sortStrategy;
	}

	public List<T> Sort<T>(List<T> list) 
	{ 
		return _sortStrategy.Sort(list);
	}
}
```

Utilisons le

```
var sortListHelper = new SortListHelper(new QuickSortStrategy());

var list = new List<string> { "Mickael", "Nicolas" };

var sortedList = sortListHelper.Sort(list);
```

Interet : Permet de réaliser des opérations de différentes manières avec une seule méthode