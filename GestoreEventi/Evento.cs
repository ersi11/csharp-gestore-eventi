using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class Evento
    {
        //attributi
        private string titolo;
        private DateTime dataAppuntamento;
        private int capienzaMaxEvento;
        private int numeroPostiPrenotati;
        public bool eventoValido;

        //getter e setter 
        private void SetTitolo(string titolo)
        {
            if (titolo == null)
            {
                throw new ArgumentNullException(nameof(titolo));
            }
            else
            {
                this.titolo = titolo;
            }
        }
        public string GetTitolo()
        {
            return this.titolo;
        }
        private void SetDataAppuntamento(DateTime dataAppuntamento)
        {
            if (dataAppuntamento < DateTime.Now)
            {
                throw new InvalidTimeZoneException(nameof(dataAppuntamento));
            }
            else
            {
                this.dataAppuntamento = dataAppuntamento;
            }
        }

        public DateTime GetDataAppuntamento()
        {
            return this.dataAppuntamento;
        }

        private void SetCapienzaMaxEvento(int capienzaMaxEvento)
        {
            if (capienzaMaxEvento < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capienzaMaxEvento));
            }
            else
            {
                this.capienzaMaxEvento = capienzaMaxEvento;
            }
        }

        public void GetCapienzaMaxEvento()
        {
            return this.capienzaMaxEvento;
        }
        public int GetNumeroPostiPrenotati()
        {
            return this.numeroPostiPrenotati;
        }


        //creo il costruttore
        public Evento(string titolo, DateTime dataAppuntamento, int capienzaMaxEvento)
        {
            try
            {
                SetTitolo(titolo);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Non hai inserito niente! " + e.ParamName);
                eventoValido = false;
            }
            try
            {
                SetDataAppuntamento(dataAppuntamento);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("La data inserita è vecchia!");
                eventoValido = false;
            }
            try
            {
                SetCapienzaMaxEvento(capienzaMaxEvento);
            } catch (ArgumentNullException e)
            {
                Console.WriteLine("Il numero inserito è sbagliata! " + e.ParamName);
            }
            this.numeroPostiPrenotati = 0;
            eventoValido = true;
        }

        // metodi

        public void NumeroPostiDisponibili()
        {
            return this.capienzaMaxEvento - this.numeroPostiPrenotati;
        }
        
        
        public void PrenotaPosti(int numeroPostiPrenotati)
        {
            if (this.dataAppuntamento < DateTime.Now)
            {
                throw new InvalidTimeZoneException();
            }
            else if (this.numeroPostiPrenotati + numeroPostiPrenotati > this.capienzaMaxEvento
                || this.numeroPostiPrenotati == this.capienzaMaxEvento)
            {
                throw new ArgumentOutOfRangeException(nameof(capienzaMaxEvento), 
                    "limite dei posti diponibili");
            }
            else if (numeroPostiPrenotati == null)
            {
                throw new ArgumentNullException(nameof(numeroPostiPrenotati));
            }
            else
            {
                this.numeroPostiPrenotati = numeroPostiPrenotati + this.capienzaMaxEvento;
            }

        }
        public void DisdiciPosti(int disdette)
        {
            if (this.dataAppuntamento < DateTime.Now)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (this.numeroPostiPrenotati - disdette 
                < 0 || NumeroPostiDisponibili() == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capienzaMaxEvento), "Non ci sono prenotazioni da disdire");

            }
            else if (disdette == null)
            {
                throw new ArgumentNullException(nameof(disdette));
            }
            else
            {
                this.numeroPostiPrenotati = this.numeroPostiPrenotati - disdette;
            }
        
        }

        public override string ToString()
        {
            string stampaEvento = "";
            stampaEvento = stampaEvento + this.dataAppuntamento.ToString("dd/MM/yyyy") + " - " + this.titolo;
            return stampaEvento;
        }

        public void StampaPosti()
        {
            Console.WriteLine("Numero posti prenotati = " + GetNumeroPostiPrenotati());
            Console.WriteLine("Numero di posti disponibili = " + GetNumeroPostiDisponibili());
        }
    } 
}
