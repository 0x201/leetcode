cmake_minimum_required(VERSION 3.20)
set(CMAKE_TOOLCHAIN_FILE "$ENV{VCPKG_ROOT}/scripts/buildsystems/vcpkg.cmake" CACHE STRING "Vcpkg toolchain file")
if (POLICY CMP0141)
  cmake_policy(SET CMP0141 NEW)
  set(CMAKE_MSVC_DEBUG_INFORMATION_FORMAT "$<IF:$<AND:$<C_COMPILER_ID:MSVC>,$<CXX_COMPILER_ID:MSVC>>,$<$<CONFIG:Debug,RelWithDebInfo>:EditAndContinue>,$<$<CONFIG:Debug,RelWithDebInfo>:ProgramDatabase>>")
endif()

set(CMAKE_CONFIGURATION_TYPES "Debug;Release" CACHE STRING "" FORCE)
set(CMAKE_C_STANDARD 17)
set(CMAKE_C_STANDARD_REQUIRED ON)

project(leetcodec)

if(NOT DEFINED CMAKE_GENERATOR AND NOT DEFINED CMAKE_MAKE_PROGRAM AND UNIX)
    find_program(NINJA_COMMAND ninja)
    if(NINJA_COMMAND)
        message(STATUS "Found Ninja: ${NINJA_COMMAND}")
        set(CMAKE_GENERATOR "Ninja" CACHE INTERNAL "")
    else()
        message(STATUS "Ninja not found, using Unix Makefiles")
        set(CMAKE_GENERATOR "Unix Makefiles" CACHE INTERNAL "")
    endif()
endif()

include_directories(${PROJECT_SOURCE_DIR}/include)

add_subdirectory("src")
add_subdirectory("test")
