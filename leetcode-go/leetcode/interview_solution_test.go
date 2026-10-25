package leetcode

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestCheckPermutation(t *testing.T) {
	assert.Equal(t, true, checkPermutation("abc", "bca"))
	assert.Equal(t, false, checkPermutation("abc", "bad"))
}
