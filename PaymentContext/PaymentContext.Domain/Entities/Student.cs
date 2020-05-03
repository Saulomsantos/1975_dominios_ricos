using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        private IList<Subscription> _subscriptions;

        // Construtor com as propriedades que devem ser passadas em uma instância de Student
        public Student(string firstName, string lastName, string document, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();
        }
        public string FirstName { get; private set; }       // Utilizando private, impede que classes externas consigam alterar um student criado
        public string LastName { get; private set; }        // caso alguma informação precise ser alterada, será necessário chamar um método para tal
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }

        // public List<Subscription> Subscriptions {get; set;}
        // Trabalhando com IReadOnlyCollection ao invés de List, previne-se que o método .Add() possa ser usado ao chamar a coleção
        // evitando assim adicionar uma assinatura sem usar o método AddSubscription, por exemplo
        public IReadOnlyCollection<Subscription> Subscriptions { get{ return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            // Se já tiver uma assinatura ativa, cancela

            // Cancela todas as outras assinaturas e coloca esta como principal
            foreach (var sub in Subscriptions)
                sub.Inactivate();

            _subscriptions.Add(subscription);
        }
    }
}