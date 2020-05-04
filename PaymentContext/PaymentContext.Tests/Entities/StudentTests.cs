using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AdicionarAssinatura()
        {
            // var subscription = new Subscription(null);

            // // Utilizando o construtor criado na classe Student.cs, o código abaixo se torna mais expressivo
            // var student = new Student("Saulo", "Santos", "12345678912", "saulo@email.com");

            // // Não é mais possível utilizar o método .Add() porque agora Subscriptions é do tipo IReadOnlyCollection
            // // student.Subscriptions.Add(subscription);

            // // Para isto, é preciso chamar o método existente
            // student.AddSubscription(subscription);
        }
    }
}