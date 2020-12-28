using System;

public class Citoyen
{
    private int cin;
    private string nom;
    private string prenom;
    private int age;
    private bool amaladieChronique;
    private bool asymptomesGrave;
    private string location;
    private bool infecté;
    private bool nonInfecté;
    private bool testPCR;
    private bool visitLieuEndemic;
    private bool suspect;

    Citoyen cn = new Citoyen();

    public void infected(Citoyen cn)
    {
        if (testPCR == true)
            infecté = true;
        else
            nonInfecté = true;

    }
    public void suspected(Citoyen cn)
    {
        if (visitLieuEndemic == true)
            suspect = true;
    }


}
