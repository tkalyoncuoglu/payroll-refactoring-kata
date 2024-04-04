from dataclasses import dataclass

@dataclass
class Employee:
    rate: int
    separated: bool
    retired: bool

@dataclass
class PayCheck:
    amount: float
    reasonCode: str


class PayrollApplication:

    @staticmethod
    def pay_amount(employee: Employee, work_hours: int) -> PayCheck:
        result = None

        if not employee.separated:
            if employee.retired:
                result = PayCheck(0, "RET")
            else:
                # Logic to compute amount
                bonus = PayrollApplication.__compute_bonus(work_hours)
                regular_amount = PayrollApplication.__compute_regular_pay_amount(employee, work_hours)
                amount = bonus + regular_amount
                result = PayCheck(amount, "EMP")
        else:
            result = PayCheck(0, "SEP")

        return result

    @staticmethod
    def __compute_bonus(work_hours: int) -> float:
        return 1000 if work_hours > 40 else 0

    @staticmethod
    def __compute_regular_pay_amount(employee: Employee, work_hours: float) -> float:
        return employee.rate * work_hours