# PuzzleGame
An isometric puzzle game with a progressive difficulty


To do:
Comportamiento de personajes:
El cubo con salta, la pramide gira como crash i tompe objetos que se puedan romper y la bola se propulsa para una direccion y si hay algo en el medio se deja de propulsar. osea con el boton de saltar el cubo salta, pero la bola y la piramide no pueden saltar, eso le da una razon al jugador para usar el cubo.

Hacer una mecanica de cuando saltas y te transformas en una bola cuando caes rebotas en el suelo.
Cuando te transformas en la piramide despues de saltar siendo el cubo das un doble salto en el aire girando

Siempre que sos la piramide y giras podes romper objetos que sean rompible, una caja de madera se puede romper y una de metal no.


cuando se transforma hacer una transision estre formas (tal vez usar particulas funcione)














Unity 2D: Grab Objects
https://www.youtube.com/watch?v=4zm8CvJPGb8

How To Grab Physics Objects In Unity
https://www.youtube.com/watch?v=bA12WEA5MLo

Unity 2D Platformer Tutorial 33 - Grab (Pick up) and Drop Objects
https://www.youtube.com/watch?v=9_hrfwlc1k4

Unity: 2D Moving Platforms
https://www.youtube.com/watch?v=GtX1p4cwYOc

Unity: 2D Platform Upgrade
https://www.youtube.com/watch?v=pWh5G17US5U

How to make a pushable button with rigidbodies in Unity
https://www.youtube.com/watch?v=fTtLY0JdVqk

Unity 3D: Animate & Trigger A Door
https://www.youtube.com/watch?v=13jceft_0PQ





modelos/arte
	cubo
	sphera
	piramide invertida
	botones
		{
		boton normal del piso (un boton en el piso del tamaño de un tile, rojo y base blanco)
		boton a precion en el piso (inspiracion: rompa en caso de emergencia, signo de exclamacion !)
		boton normal para precionar (boton en un pilar, que se preciona con el boton de precionar).
		}
	puerta
	cubos
		{
		sprite normal
		sprite de madera
		}
	hamburger con una vela



*Grab Objects
*Pusheable button
*Plataform
*Door

*Movimiento
*Salto
*Camara
*Cambiar de forma 
{
diferentes stats
	{
	Cubo: mas lento, salta menos...;
	Sphera: mas rapido, salta normal...;
	Piramide Invertida: velocidad normal, salta normal, planea en el aire(se le puede aumentar el linear drag cuando cae);
	}
cambia de modelos
	{
	modeleos de cubo, sphera, piramide invertida
	}
}

3 niveles de tutorial



Player
{
script
Player : stats
public StatsSO CurrentStats => _stats;
[Serializefield] private StatsSO _stats;


public float Speed => _speed;
[SerializeField] private float_speed;

initData(StatsSO data)
{
	_speed = data.Speed;
	_liniarDrag = data.LiniarDrag;
}
bola
	{
	stats
	public StatsSO Stats => _stats;
	[Serializefield] private StatsSO _stats; 

}

un evento en el script de cambiar de forma

Movement : IChangable


Awake()
{
	se subscribe al evento (SetStats);

}


void SetStats()
{
speed = player.CurrentStats.Speed;
....
}































































































































































































































































































































































































reedme
