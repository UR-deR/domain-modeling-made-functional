// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

type Topic = 
| DailyConversation
| Pronunciation
| Grammar
| Vocabulary

type Place = 
| Online
| OnCampus

type SessionDetail = {
    Duration: int // from 30 mins to 60 mins
    Place: Place
    Topic: Topic
}

type UnvalidatedSessionDetail = SessionDetail
type ValidatedSessionDetail = SessionDetail

type UnvalidatedBooking = {
    StudentNumber: string
    BookingId: string
    SessionDetail: UnvalidatedSessionDetail
}

type ValidatedBooking = {
    StudentNumber: string
    BookingId: string
    SessionDetail: ValidatedSessionDetail
}

type Result<'Success, 'Failures> =
| Success of 'Success
| Failure of 'Failures

type AsyncResult<'Success, 'Failures> = Async<Result<'Success, 'Failures>>

type ValidateBooking = UnvalidatedBooking -> AsyncResult<ValidatedBooking, ValidationError list>
and ValidationError = {
    FieldName: string
    ErrorDescription: string
}

type BookingCompleted = Undefined

type PlaceBooking = ValidatedBooking -> AsyncResult<BookingCompleted, BookingError list>
and BookingError = {
    ErrorDescription: string
}

type NotificationSent = Undefined

type NofifyStudent = BookingCompleted -> AsyncResult<NotificationSent, NotificationError list>
and NotificationError = {
    ErrorDescription: string
}


// let bookConservationSession
//     (validateBooking: ValidateBooking)
//     (placeBooking: PlaceBooking)
//     (notifyStudent: NofifyStudent)
//     (unvalidatedBooking: UnvalidatedBooking) =
//     async {
//         let! validatedBooking = validateBooking unvalidatedBooking
//         let! _ = placeBooking validatedBooking
//         let! _ = notifyStudent BookingCompleted.Undefined
//         return ()
//     }
