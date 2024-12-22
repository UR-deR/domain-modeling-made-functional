// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

type Place = 
| Online
| OnCampus

type Language = 
| English
| Japanese

type StartAt = StartAt of System.DateTime

type EndAt = EndAt of System.DateTime

type StudentCode = StudentCode of string
type SessionDetail = {
    Place: Place
    Language: Language
    StartAt: StartAt
    EndAt: EndAt
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

type Result<'success, 'failures> =
| Success of 'success
| Failure of 'failures

type AsyncResult<'success, 'failures> = Async<Result<'success, 'failures>>

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
