using TesteApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace TesteApp.Services
{
    public static class TarefaService
    {
        static List<TodoItem> Tarefas {get;}
        static int nextId = 3;
        static TarefaService()
        {
            Tarefas = new List<TodoItem>
            {
                new TodoItem {Id = 1, Name = "Montar API", Completo = false },
                new TodoItem {Id = 2, Name = "Montar Site", Completo = true}
            };
        }
        public static List<TodoItem> GetAll() => Tarefas;

        public static TodoItem Get(int id) => Tarefas.FirstOrDefault(p => p.Id == id);

        public static void Add(TodoItem tarefas)
        {
            tarefas.Id = nextId++;
            Tarefas.Add(tarefas);
        }

        public static void Delete(int id)
        {
            var tarefas = Get(id);
            if (tarefas is null)
                return;
            Tarefas.Remove(tarefas);
        }

        public static void Update(TodoItem tarefas)
        {
            var index = Tarefas.FindIndex(p => p.Id == tarefas.Id);
            if (index == -1)
                return;
            Tarefas[index] = tarefas;
        }
    }
}