export interface Form {
    id: number
    name: string
    description: string
    fields: Field[]
}

export interface Field {
    id: number
    title: string
    type: string
    content: string
    formId: number
    form?: any
}