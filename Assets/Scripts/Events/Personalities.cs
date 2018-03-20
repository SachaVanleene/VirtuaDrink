using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personality {
    public string titre, nom, profession, age, description, atout, handicap, bouton;
}

public static class Personalities {
    private static Dictionary<int, Personality> _conv = new Dictionary<int, Personality> {
        //Personalité 1 (par défaut) : Ernest -> rôle patient
        {1, new Personality {   titre = "Personnalité N°1",
                                nom = "Ernest Fringuant",
                                profession = "Boucher",
                                age = "32 ans",
                                description = "Père de famille et vie ordinaire était votre quotidien. Mais tout a basculé le jour où vous avez accidentellement confondu un gigot avec la main d’une cliente. Vous étiez pourtant sûr d’avoir vu ce gigot flotter dans les airs mais rien à faire, personne ne vous croit… Ainsi, vous finissez en asile persuadé d’être sain d’esprit.",
                                atout = "Aimé des autres patients, ils se confient toujours à vous.",
                                handicap = "Vous n’êtes pas censé vous échapper, ce n'est pas bien !",
                                bouton = "Touche 1 pour accéder au personnage" }
        },
        //Personalité 2 : Jean-Eude -> rôle médecin
        {2, new Personality {   titre = "Personnalité N°2",
                                nom = "Jean-Eude Marseault",
                                profession = "Médecin",
                                age = "47 ans",
                                description = "Après de longues années d’études en médecine, vous avez décidé de vous spécialiser dans la chirurgie esthétique. Votre rêve ? Rendre le monde plus beau. Suite à une erreur fatale sur une patiente, vous vous êtes retrouvé sans travail mais vous continuez de côtoyer vos semblables dans la vie de tous les jours en attente de votre retour à l’heure de gloire.",
                                atout = "Vous êtes un maître du dialogue avec le personnel de l’asile.",
                                handicap = "Vos talents incomparables sont souvents sollicités par les autres médecins.",
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