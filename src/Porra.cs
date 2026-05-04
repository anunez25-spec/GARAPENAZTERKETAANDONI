using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3POO_5
{
    /// <summary>
    /// Txapelketa-porra baten parte-hartzaile baten datuak eta puntuazio-logika kudeatzen ditu.
    /// Erabiltzaile bakoitzaren izena, irabazlearen aurreikuspena, finalistaren izena,
    /// goleatzailearen izena eta metatutako puntuak gordetzen ditu.
    /// </summary>
    class Porra
    {
        /// <summary>Parte-hartzailearen izena.</summary>
        private string izena;

        /// <summary>Parte-hartzaileak irabazle izango dela aurreikusitako taldearen izena.</summary>
        private string irabazlea;

        /// <summary>Parte-hartzaileak finalera iritsiko dela uste duen bigarren taldearen izena.</summary>
        private string finalista;

        /// <summary>Parte-hartzaileak goleatzaile izango dela uste duen jokalariren izena.</summary>
        private string goleatzailea;

        /// <summary>Parte-hartzaileak metatutako puntu kopurua.</summary>
        private int puntuak;

        /// <summary>Parte-hartzailearen izena eskuratzen edo ezartzen du.</summary>
        /// <value>Parte-hartzailearen izena duen kate bat.</value>
        public string Izena { get => izena; set => izena = value; }

        /// <summary>Irabazlea izango dela aurreikusitako taldearen izena eskuratzen edo ezartzen du.</summary>
        /// <value>Irabazlearen talde-izena.</value>
        public string Irabazlea { get => irabazlea; set => irabazlea = value; }

        /// <summary>Finalista izango dela aurreikusitako taldearen izena eskuratzen edo ezartzen du.</summary>
        /// <value>Finalistaren talde-izena.</value>
        public string Finalista { get => finalista; set => finalista = value; }

        /// <summary>Goleatzailea izango dela aurreikusitako jokalariren izena eskuratzen edo ezartzen du.</summary>
        /// <value>Goleatzailearen jokalari-izena.</value>
        public string Goleatzailea { get => goleatzailea; set => goleatzailea = value; }

        /// <summary>Parte-hartzailearen puntu-kopurua eskuratzen edo ezartzen du.</summary>
        /// <value>Metatutako puntu kopuru osoa.</value>
        public int Puntuak { get => puntuak; set => puntuak = value; }

        /// <summary>
        /// <see cref="Porra"/> klasearen instantzia berri bat hasieratzen du emandako parametroekin.
        /// </summary>
        /// <param name="i">Parte-hartzailearen izena.</param>
        /// <param name="ir">Irabazlea izango dela aurreikusitako taldearen izena.</param>
        /// <param name="fi">Finalista izango dela aurreikusitako taldearen izena.</param>
        /// <param name="go">Goleatzailea izango dela aurreikusitako jokalariren izena.</param>
        /// <param name="p">Hasierako puntu kopurua (fitxategitik irakurrita).</param>
        public Porra(string i, string ir, string fi, string go, int p)
        {
            this.izena = i;
            this.irabazlea = ir;
            this.finalista = fi;
            this.goleatzailea = go;
            this.puntuak = p;
        }

        /// <summary>
        /// Porrako parte-hartzailearen datu guztiak giza-irakurgarri diren formatuan itzultzen ditu
        /// kontsolan bistaratzeko.
        /// </summary>
        /// <returns>
        /// Parte-hartzailearen izen, irabazle, finalista, goleatzaile eta puntuak barne hartzen
        /// dituen kate formateatua. 
        /// Adibidea: <c>TALDEA=Mikel, bere IRABAZLEA=Espania, beste FINALISTA=Brasil, GOLEATZAILEA=Lamine eta PUNTUAK=45</c>
        /// </returns>
        public string Pantailaratu()
        {
            return "TALDEA=" + izena + ", bere IRABAZLEA=" + irabazlea + ", beste FINALISTA=" + finalista + ", GOLEATZAILEA=" + goleatzailea + " eta PUNTUAK=" + puntuak;
        }

        /// <summary>
        /// Porrako parte-hartzailearen datu guztiak gidoi bidez bereizitako formatuan itzultzen ditu
        /// fitxategian gordetzeko.
        /// </summary>
        /// <returns>
        /// Gidoi bidez bereizitako kate bat: <c>izena-irabazlea-finalista-goleatzailea-puntuak</c>.
        /// Adibidea: <c>Mikel-Espania-Brasil-Lamine-45</c>
        /// </returns>
        public override string ToString()
        {
            return izena + "-" + irabazlea + "-" + finalista + "-" + goleatzailea + "-" + puntuak;
        }

        /// <summary>
        /// Irabazlea asmatzeagatik 25 puntu gehitzen dizkio parte-hartzaileari
        /// eta eguneratutako puntu kopurua itzultzen du.
        /// </summary>
        /// <returns>Uneko puntuei 25 gehituta lortutako puntu kopuru berria.</returns>
        public int AsmatuIrabazlea()
        {
            return (puntuak + 25);
        }

        /// <summary>
        /// Bi finalistak asmatzeagatik 20 puntu gehitzen dizkio parte-hartzaileari
        /// eta eguneratutako puntu kopurua itzultzen du.
        /// </summary>
        /// <returns>Uneko puntuei 20 gehituta lortutako puntu kopuru berria.</returns>
        public int AsmatuBiFinalistak()
        {
            return (puntuak + 20);
        }

        /// <summary>
        /// Gol baten egilea asmatzeagatik 3 puntu gehitzen dizkio parte-hartzaileari
        /// eta eguneratutako puntu kopurua itzultzen du.
        /// </summary>
        /// <returns>Uneko puntuei 3 gehituta lortutako puntu kopuru berria.</returns>
        public int Goleko()
        {
            return (puntuak + 3);
        }
    }
}
