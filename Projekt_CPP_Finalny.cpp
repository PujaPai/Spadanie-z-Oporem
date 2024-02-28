#include <stdio.h>
#include <math.h>

#define PI 3.14

double predkosc(double a, double pred, double dt) //Obliczanie Prędkości spadania obiektu
{
    return pred + a * dt;
}

double opor(double gest, double pole, double wskaz, double pred) //Obliczanie Oporu powietrza
{
    return 0.5 * gest * fabs(pred) * pred * pole * wskaz;
}

double EnergPo(double masa, double wys, double grav) //Obliczanie Energi Potencjalnej
{
    return masa * grav * wys;
}

double EnergKi(double masa, double pred) //Obliczanie Energi Kinerycznej
{
    return 0.5 * masa * pred * pred;
}

void JednoPlik(double t, double h, double v, double a, double pe, double ke) //Jednoski po naszych danych
{
    printf("Czas: %.2f s, Wysokosc: %.2f m, Predkosc: %.2f m/s, Przyspieszenie: %.2f m/s^2 Energia Potencjalna: %.2f J, Energia Kinetyczna: %.2f J\n", t, h, v, a, pe, ke);
}

void WpiszPlik(FILE *file, double t, double h, double v, double a, double pe, double ke) //Wpisywanie do pliku naszych danych
{
    fprintf(file, "%.2f %.2f %.2f %.2f %.2f %.2f \n", t, h, v, a, pe, ke);
}

int main() {
    double a, t, fO, v, r, m, fG, p, rho, cD, h, vLim, dt, pe, ke;

    a = 9.81;
    t = 0;
    fO = 0;
    v = 0;
    dt = 0.1;

    FILE *outputFile = fopen("Spadajacy_Przedmiot.txt", "w");
    if (outputFile == NULL) {
        printf("Error otworzenia Pliku.\n");
        return 1; // Zakończenie programu z kodem błędu
    }
    fprintf(outputFile, "|t| |h| |v| |a| |EP| |EK|\n");
    printf("Wybierz ksztalt spadajacego obiektu (1: Kula, 2: Szescian, 3: Kropla wody): ");
    int figura;
    scanf("%d", &figura);

    switch (figura) {
        case 1: // Kula
            cD = 0.47;
            printf("Wprowadz promien [m], mase [kg] i wysokosc [m] kuli (po spacji): ");
            scanf("%lf %lf %lf", &r, &m, &h);
            p = (r * r * PI);
            break;
        case 2: // Szescian
            cD = 1.05;
            printf("Wprowadz bok [m], mase [kg] i wysokosc [m] szescianu (po spacji): ");
            scanf("%lf %lf %lf", &r, &m, &h);
            p = (r * r);
            break;
        case 3: // Kropla wody
            cD = 0.04;
            printf("Wprowadz promien [m], mase [kg] i wysokosc [m] kropli wody (po spacji): ");
            scanf("%lf %lf %lf", &r, &m, &h);
            p = (r * r * PI);
            break;
        default:
            printf("Zly wybor figury\n");
            return 1; // Zakończenie programu z kodem błędu
    }

    printf("Wybierz pore roku (1: Lato, 2: Zima, 3: Wiosna, 4: Jesien): ");
    int Pora;
    scanf("%d", &Pora);

    switch (Pora) {
        case 1: // Lato
            rho = 1.209;
            break;
        case 2: // Zima
            rho = 1.288;
            break;
        case 3: // Wiosna
            rho = 1.257;
            break;
        case 4: // Jesien
            rho = 1.248;
            break;
        default:
            printf("Zly wybor pory roku.\n");
            return 1; // Zakończenie programu z kodem błędu
    }

    fG = m * a;
    vLim = sqrt((2 * fG) / (rho * p * cD));

    while (h > 0) {
        if (v <= vLim || v == 0) {
            v = predkosc(a, v, dt);
            fO = opor(rho, p, cD, v);
        }

        a = fabs(fG - fO) / m;
        h = h - (v * dt) + (0.5 * a * dt * dt); // Aktualizacja wysokości po prędkości i przyspieszenia
        t += dt;

        pe = EnergPo(m, h, a);
        ke = EnergKi(m, v);

        JednoPlik(t, h, v, a, pe, ke);
        WpiszPlik(outputFile, t, h, v, a, pe, ke);
    }

    if (v > vLim)
        printf("Koncowa Predkosc: %.2f m/s\n", vLim);
    else
        printf("Koncowa Predkosc: %.2f m/s\n", v);

    printf("Czas Spadania: %.2f s\n", t);

    fclose(outputFile);
    return 0;
}
