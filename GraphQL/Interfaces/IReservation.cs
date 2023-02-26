using GraphQLProject.Models;

namespace GraphQLProject.Interfaces;

public interface IReservation
{
    List<Reservation> GetReservations();
    Reservation AddReservation(Reservation reservation);
}
