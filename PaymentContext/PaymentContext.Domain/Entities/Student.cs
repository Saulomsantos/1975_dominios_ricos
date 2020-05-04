using System.Collections.Generic;
using System.Linq;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;

        // Construtor com as propriedades que devem ser passadas em uma instância de Student
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }

        // Utilizando private nas props, impede que classes externas consigam alterar um student criado
        // caso alguma informação precise ser alterada, será necessário chamar um método para tal

        // public List<Subscription> Subscriptions {get; set;}
        // Trabalhando com IReadOnlyCollection ao invés de List, previne-se que o método .Add() possa ser usado ao chamar a coleção
        // evitando assim adicionar uma assinatura sem usar o método AddSubscription, por exemplo
        public IReadOnlyCollection<Subscription> Subscriptions { get{ return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            // Cancela todas as outras assinaturas e coloca esta como principal
            foreach (var sub in Subscriptions)
                sub.Inactivate();

            _subscriptions.Add(subscription);
        }
    }
}