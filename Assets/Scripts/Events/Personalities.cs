using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personality {
    public string titre, nom, profession, age, description, atout, handicap, bouton;
}

public static class Personalities {
    private static Dictionary<int, Personality> _conv = new Dictionary<int, Personality> {
        //Personalité 1 (par défaut) : Ernest -> rôle patient
        {1, new Personality {   titre = "Victime N°1",
                                nom = "Hervé Tremblay",
                                profession = "Moniteur d'auto école",
                                age = "34 ans",
                                description = "Hervé était un père de famille de 3 enfants.  Hervé était aimé de tous et passioné de footbal américain. Ce jour-là, Hervé revenait de son travail lorsqu'il trouva la mort par votre faute à cause de l'accident que vous avez provoqué. Hervé n'avait rien demandé, vous avez gâché sa vie et celle de sa famille",
                                atout = "Après la mort de son mari, sa femme Gabrielle tomba en grave dépression et ses enfants ne se remirent jamais de ce drame, cela les a traumatisé à vie. Le plus grand, Sébastien, a même arrêté ses études, il n'était plus capable de les poursuivre.",
                                handicap = "Par votre faute, Hervé n'a pas eu la chance de survivre",
                                bouton = "Touche 1 pour accéder au personnage" }
        },
        //Personalité 2 : Jean-Eude -> rôle médecin
        {2, new Personality {   titre = "Victimes N°2",
                                nom = "Marc, Aurore et Julien",
                                profession = "Etudiants",
                                age = "21-20-22 ans",
                                description = "Ce groupe d'amis, étudiant en biologie n'avait aucun problème. De nature très responsable ces derniers n'avaient jamais connu un tel accident",
                                atout = "Suite à l'accident, Julien n'a pu remonter dans une voiture qu'après 4ans, car il était trop térrorifié. Marc a perdu l'usage de son bras droit pendant un an suite à une triple fracture sur le bras droit. Aurore a été brulée au 3ème degré sur 40 % du corps suite à l'incendie qui s'est déclenché",
                                handicap = "Fractures temporaires mais cicatrices physiques et psychologiques permanentes, par votre faute ce gorupe d'amis abandonna beaucoup de projets qu'ils auraient voulu faire",
                                bouton = "Touche 2 pour accéder au personnage" }
        },
        //Personalité 3 : Jack -> rôle garde
        {3, new Personality {   titre = "Personnalité N°3 ",
                                nom = "Jack Boxer",
                                profession = "Gardien d’asile",
                                age = "22 ans",
                                description = "Seul sain d’esprit parmi une famille de fous, vous avez pris l’habitude de vous occuper de votre famille dès le plus jeune âge.Courses, factures, repassage, vous étiez sur tous les fronts. Mais un beau jour, l’assistante sociale a jugé que vous ne pouviez pas, du haut de vos 10 ans, continuer de faire tout cela. 12 ans plus tard, vous devenez gardien d’asile et êtes de retour auprès de votre famille.",
                                atout = "Vous pouvez circuler tranquillement en présence des gardiens à votre poursuite.",
                                handicap = "Vous prenez les patients pour votre famille du coup votre taux de folie augmente plus vite que la normale.",
                                bouton = "Touche 3 pour accéder au personnage" }
        },
    };

    public static Personality GetPerso(int id) {
        Personality text;
        _conv.TryGetValue(id, out text);
        return text;
    }
}