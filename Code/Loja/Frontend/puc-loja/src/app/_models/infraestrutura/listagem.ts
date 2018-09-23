import { Paginacao } from "./paginacao";

export class Listagem<T> {
    lista: T[];
    paginacao: Paginacao;
}