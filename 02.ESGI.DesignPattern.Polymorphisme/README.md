# Rappels

## Classe

```
public class MaClasse
{
	private int unAttribut;

	public string UnePropriete {get;set;}

	public MaClasse()
	{
	}

	public void UneMethode(string unParametre)
	{
		Console.WriteLine($"{unParametre} ${UnePropriete} {unAttribut}");
	}
}
```

## Héritage

```
public class MaClasseDeBase
{
	public void UneMethodeDeBase() { }
	public virtual void UneMethodePouvantEtreSpecialisee() { }
}

public class MaClasseSpecialisee : MaClasseDeBase
{
	public override void UneMethodePouvantEtreSpecialisee() { }
}
```

## Interface

```
public interface IUneInterface
{
	void UneMethode(int unParametre);
	string UneAutreMethode();
}

public class MaClasse : IUneInterface
{
	public void UneMethode(int unParametre) { }
	public string UneAutreMethode() { return "Greeting"; }
}
```

## Polymorphisme

Imaginons le code suivant

```
public abstract class Personnage
{
	public abstract void AttaqueSpeciale();
}

public class Sorcier : Personnage
{
	public void AttaqueSpeciale() 
	{ 
		Console.WriteLine("Boule de feu");
	}
}

public class Guerrier : Personnage
{
	public void AttaqueSpeciale() 
	{ 
		Console.WriteLine("Coup de boule");
	}
}
```

Comme Sorcier et Guerrier sont des personnages il est possible de constituer une équipe composée de personnages qui auront leurs propres spécificités et comportements sans jamais que cela n'apparaisse au niveau de l'équipe

```
public class Equipe
{
	private List<Personnage> personnages;

	public Equipe(List<Personnage> personnages)
	{
		this.personnages = personnages;
	}

	public void AttaqueSpecialeGroupee()
	{
		foreach (var personnage in personnages)
		{
			personnage.AttaqueSpeciale();
		}
	}
}
```

Interet : Permet de manipuler des objets selon leurs formes de base ou leurs de contrats tout en les laissant se comporter de manière spécifique