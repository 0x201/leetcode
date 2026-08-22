package leetcode

type ATM struct {
	count  []int64
	values []int64
}

const (
	numDenominations = 5
	invalidResult    = -1
)

var denominations = [numDenominations]int64{20, 50, 100, 200, 500}

func ATMConstructor() *ATM {
	return &ATM{
		count:  make([]int64, numDenominations),
		values: denominations[:],
	}
}

func (a *ATM) Deposit(banknotesCount []int) {
	for i := 0; i < numDenominations; i++ {
		a.count[i] += int64(banknotesCount[i])
	}
}

func (a *ATM) Withdraw(amount int) []int {
	res := make([]int, numDenominations)
	tempAmount := int64(amount)

	for i := numDenominations - 1; i >= 0; i-- {
		maxPossible := tempAmount / a.values[i]
		res[i] = int(min(a.count[i], maxPossible))
		tempAmount -= int64(res[i]) * a.values[i]
	}

	if tempAmount > 0 {
		return []int{invalidResult}
	}

	for i := 0; i < numDenominations; i++ {
		a.count[i] -= int64(res[i])
	}
	return res
}
