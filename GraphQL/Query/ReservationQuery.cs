﻿using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;

namespace GraphQLProject.Query;

public class ReservationQuery : ObjectGraphType
{
    public ReservationQuery(IReservation reservationService)
    {
        Field<ListGraphType<ReservationType>>("reservations", resolve : context => reservationService.GetReservations());
    }
}
