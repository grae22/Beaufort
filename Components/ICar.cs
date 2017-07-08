namespace Components
{
  interface ICar
  {
    IEngine Engine { set; }

    double SpeedKph { get; }
  }
}
