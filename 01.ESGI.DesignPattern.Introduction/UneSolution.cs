using Xunit;

namespace _01.ESGI.DesignPattern.Introduction
{
    public abstract class Kebab
    {
        public virtual bool Vegetarien { get; }
        public virtual bool Pescetarian { get; }
        public abstract Kebab SansOignon();
    }

    public class Pain : Kebab
    {
        public override bool Vegetarien => true;
        public override bool Pescetarian => true;
        public override Kebab SansOignon() => this;
    }

    public class Salade : Kebab
    {
        private Kebab inner;

        public Salade(Kebab inner)
        {
            this.inner = inner;
        }

        public override bool Vegetarien => inner.Vegetarien;
        public override bool Pescetarian => inner.Pescetarian;
        public override Kebab SansOignon() => this;
    }

    public class Viande : Kebab
    {
        private Kebab inner;

        public Viande(Kebab inner)
        {
            this.inner = inner;
        }

        public override bool Vegetarien => false;
        public override bool Pescetarian => false;
        public override Kebab SansOignon() => this;
    }

    public class Poisson : Kebab
    {
        private Kebab inner;

        public Poisson(Kebab inner)
        {
            this.inner = inner;
        }

        public override bool Vegetarien => false;
        public override bool Pescetarian => inner.Pescetarian;
        public override Kebab SansOignon() => this;
    }

    public class Tomate : Kebab
    {
        private Kebab inner;

        public Tomate(Kebab inner)
        {
            this.inner = inner;
        }

        public override bool Vegetarien => inner.Vegetarien;
        public override bool Pescetarian => inner.Pescetarian;
        public override Kebab SansOignon() => this;
    }

    public class Oignon : Kebab
    {
        private Kebab inner;

        public Oignon(Kebab inner)
        {
            this.inner = inner;
        }

        public override bool Vegetarien => inner.Vegetarien;
        public override bool Pescetarian => inner.Pescetarian;

        public override Kebab SansOignon()
        {
            return inner;
        }
    }

    public class Playground
    {
        [Fact]
        public void Vegetarien()
        {
            Kebab kebab = new Salade(new Tomate(new Pain()));

            Assert.True(kebab.Vegetarien);

            kebab = new Salade(new Poisson(new Tomate(new Pain())));

            Assert.False(kebab.Vegetarien);

            kebab = new Salade(new Viande(new Tomate(new Pain())));

            Assert.False(kebab.Vegetarien);
        }

        [Fact]
        public void Pescetarian()
        {
            Kebab kebab = new Salade(new Tomate(new Pain()));

            Assert.True(kebab.Pescetarian);

            kebab = new Salade(new Poisson(new Tomate(new Pain())));

            Assert.True(kebab.Pescetarian);

            kebab = new Salade(new Viande(new Tomate(new Pain())));

            Assert.False(kebab.Pescetarian);
        }
    }
}
